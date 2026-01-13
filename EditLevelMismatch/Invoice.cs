using Csla;
using Csla.Core.FieldManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EditLevelMismatch
{
    public class Invoice : BusinessBase<Invoice>
    {
        public static readonly PropertyInfo<string> InvoiceNumberProperty = RegisterProperty<string>(o => o.InvoiceNumber);
        public string InvoiceNumber
        {
            get => GetProperty(InvoiceNumberProperty);
            set => SetProperty(InvoiceNumberProperty, value);
        }

        public static readonly PropertyInfo<CostList> CostsProperty = RegisterProperty<CostList>(o => o.Costs);
        public CostList Costs
        {
            get => GetProperty(CostsProperty);
            set => SetProperty(CostsProperty, value);
        }

        [Create()]
        void Create()
        {
            LoadProperty(InvoiceNumberProperty, "NewInvoice");
            LoadProperty(CostsProperty, ApplicationContext.CreateInstanceDI<DataPortal<CostList>>().CreateChild());

        }


        public class Cost : BusinessBase<Cost>
        {

            public static readonly PropertyInfo<string> CostNameProperty = RegisterProperty<string>(o => o.CostName);
            public string CostName
            {
                get => GetProperty(CostNameProperty);
                set => SetProperty(CostNameProperty, value);
            }

            public FieldDataManager GetFieldManager() => FieldManager;



            [CreateChild()]
            void Create()
            {
            }
        }

        public class CostList : BusinessListBase<CostList, Cost>
        {
            [CreateChild()]
            void Create()
            {
                AddNew();
                this.First().CostName = "NewCost";
            }
        }
    }
}
