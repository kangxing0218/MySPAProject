﻿using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Abp.UI;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MySpaProject;
using MySpaProject.PhoneBook.Persons.Authorization;
using MySpaProject.PhoneBook.Persons.DomainServices;
using MySpaProject.PhoneBook.PhoneBooks.Persons.Dtos;
using MySpaProject.PhoneBook.PhoneBooks.PhoneNumbers;
using MySpaProject.PhoneBook.PhoneBooks.PhoneNumbers.Dtos;

namespace MySpaProject.PhoneBook.PhoneBooks.Persons
{
    /// <summary>
    ///     Person应用层服务的接口实现方法
    /// </summary>
    [AbpAuthorize(PersonAppPermissions.Person)]
    public class PersonAppService : MySpaProjectAppServiceBase, IPersonAppService
    {
        private readonly IPersonManager _personManager;

        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        private readonly IRepository<Person, int> _personRepository;

        private readonly IRepository<PhoneNumber, long> _phoneNumbeRepository;

        /// <summary>
        ///     构造函数
        /// </summary>
        public PersonAppService(IRepository<Person, int> personRepository
            , IPersonManager personManager, IRepository<PhoneNumber, long> phoneNumbeRepository)
        {
            _personRepository = personRepository;
            _personManager = personManager;
            _phoneNumbeRepository = phoneNumbeRepository;
        }

        /// <summary>
        ///     获取Person的分页列表信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PersonListDto>> GetPagedPersons(GetPersonsInput input)
        {
            var query = _personRepository.GetAll().Include(a=>a.PhoneNumbers).WhereIf(!input.Filter.IsNullOrWhiteSpace(),
                a => a.Name.Contains(input.Filter) || a.Address.Contains(input.Filter) ||
                     a.EmailAddress.Contains(input.Filter));
            //TODO:根据传入的参数添加过滤条件
            var personCount = await query.CountAsync();

            var persons = await query
                .OrderBy(input.Sorting).AsNoTracking()
                .PageBy(input)
                .ToListAsync();

            //var personListDtos = ObjectMapper.Map<List <PersonListDto>>(persons);
            var personListDtos = ObjectMapper.Map<List<PersonListDto>>(persons);

            return new PagedResultDto<PersonListDto>(
                personCount,
                personListDtos
            );
        }

        /// <summary>
        ///     通过指定id获取PersonListDto信息
        /// </summary>
        public async Task<PersonListDto> GetPersonByIdAsync(EntityDto<int> input)
        {
            var entity = await _personRepository.GetAsync(input.Id);

            return ObjectMapper.Map<PersonListDto>(entity);
        }

        /// <summary>
        ///     导出Person为excel表
        /// </summary>
        /// <returns></returns>
        /// <summary>
        ///     MPA版本才会用到的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetPersonForEditOutput> GetPersonForEdit(NullableIdDto<int> input)
        {
            var output = new GetPersonForEditOutput();
            PersonEditDto personEditDto;

            if (input.Id.HasValue)
            {
                var entity = await _personRepository.GetAsync(input.Id.Value);

                personEditDto = ObjectMapper.Map<PersonEditDto>(entity);

                //personEditDto = ObjectMapper.Map<List <personEditDto>>(entity);
            }
            else
            {
                personEditDto = new PersonEditDto();
            }

            output.Person = personEditDto;
            return output;
        }

        /// <summary>
        ///     添加或者修改Person的公共方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task CreateOrUpdatePerson(CreateOrUpdatePersonInput input)
        {
            if (input.Person.Id.HasValue)
                await UpdatePersonAsync(input.Person);
            else
                await CreatePersonAsync(input.Person);
        }

        /// <summary>
        ///     删除Person信息的方法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAuthorize(PersonAppPermissions.Person_DeletePerson)]
        public async Task DeletePerson(EntityDto<int> input)
        {
            //TODO:删除前的逻辑判断，是否允许删除
            await _personRepository.DeleteAsync(input.Id);
        }

        /// <summary>
        ///     批量删除Person的方法
        /// </summary>
        [AbpAuthorize(PersonAppPermissions.Person_BatchDeletePersons)]
        public async Task BatchDeletePersonsAsync(List<int> input)
        {
            //TODO:批量删除前的逻辑判断，是否允许删除
            await _personRepository.DeleteAsync(s => input.Contains(s.Id));
        }

        /// <summary>
        ///     为联系人添加电话号码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PhoneNumberListDto> AddPhoneNumberAsync(PhoneNumberEditDto input)
        {
            var person = await _personRepository.GetAsync(input.PersonId);

            await _personRepository.EnsureCollectionLoadedAsync(person, p => p.PhoneNumbers);

            var phoneNumber = ObjectMapper.Map<PhoneNumber>(input);

            person.PhoneNumbers.Add(phoneNumber);

            await CurrentUnitOfWork.SaveChangesAsync();

            return ObjectMapper.Map<PhoneNumberListDto>(phoneNumber);
        }

        /// <summary>
        ///     删除电话号码信息
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task DeletePhoneNumberAsync(EntityDto<long> input)
        {
            var entity = await _phoneNumbeRepository.GetAsync(input.Id);
            if (entity != null)
            {
                await _phoneNumbeRepository.DeleteAsync(entity);
            }
            else
            {
                throw new UserFriendlyException("该电话号码不存在，请重试");

            }


        }

        /// <summary>
        ///     新增Person
        /// </summary>
        [AbpAuthorize(PersonAppPermissions.Person_CreatePerson)]
        protected virtual async Task<PersonEditDto> CreatePersonAsync(PersonEditDto input)
        {
            //TODO:新增前的逻辑判断，是否允许新增
            var entity = ObjectMapper.Map<Person>(input);

            entity = await _personRepository.InsertAsync(entity);
            return ObjectMapper.Map<PersonEditDto>(entity);
        }

        /// <summary>
        ///     编辑Person
        /// </summary>
        [AbpAuthorize(PersonAppPermissions.Person_EditPerson)]
        protected virtual async Task UpdatePersonAsync(PersonEditDto input)
        {
            //TODO:更新前的逻辑判断，是否允许更新
            var entity = await _personRepository.GetAsync(input.Id.Value);
            ObjectMapper.Map(input,entity);

            // ObjectMapper.Map(input, entity);
            await _personRepository.UpdateAsync(entity);
        }
    }
}