using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySpaProject
{
    public class MySpaProjectDomainServiceBase : DomainService
    {
        ////BCC/ BEGIN CUSTOM CODE SECTION
        ////ECC/ END CUSTOM CODE SECTION
        /* Add your common members for all your domain services. */
        /*在领域服务中添加你的自定义公共方法*/
        protected MySpaProjectDomainServiceBase()
        {
            LocalizationSourceName = MySpaProjectConsts.LocalizationSourceName;
        }
    }
}
