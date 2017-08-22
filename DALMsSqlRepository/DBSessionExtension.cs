
 
 using IDALRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALMsSqlRepository
{
	public partial class DBSession:IDBSession
    {
		 IFW_AUDIT_RECORD_REPOSITORY iFW_AUDIT_RECORD_REPOSITORY;
		public IFW_AUDIT_RECORD_REPOSITORY IFW_AUDIT_RECORD_REPOSITORY
		 {
            get
            {
               if( iFW_AUDIT_RECORD_REPOSITORY==null)
					iFW_AUDIT_RECORD_REPOSITORY=new FW_AUDIT_RECORD_REPOSITORY();
			   	return iFW_AUDIT_RECORD_REPOSITORY;
            }
            set
            {
               iFW_AUDIT_RECORD_REPOSITORY=value;
            }
        }

		 IFW_GEO_NODE_REPOSITORY iFW_GEO_NODE_REPOSITORY;
		public IFW_GEO_NODE_REPOSITORY IFW_GEO_NODE_REPOSITORY
		 {
            get
            {
               if( iFW_GEO_NODE_REPOSITORY==null)
					iFW_GEO_NODE_REPOSITORY=new FW_GEO_NODE_REPOSITORY();
			   	return iFW_GEO_NODE_REPOSITORY;
            }
            set
            {
               iFW_GEO_NODE_REPOSITORY=value;
            }
        }

		 IFW_GEO_NODE_CUST_REPOSITORY iFW_GEO_NODE_CUST_REPOSITORY;
		public IFW_GEO_NODE_CUST_REPOSITORY IFW_GEO_NODE_CUST_REPOSITORY
		 {
            get
            {
               if( iFW_GEO_NODE_CUST_REPOSITORY==null)
					iFW_GEO_NODE_CUST_REPOSITORY=new FW_GEO_NODE_CUST_REPOSITORY();
			   	return iFW_GEO_NODE_CUST_REPOSITORY;
            }
            set
            {
               iFW_GEO_NODE_CUST_REPOSITORY=value;
            }
        }

		 IFW_GEO_TREE_REPOSITORY iFW_GEO_TREE_REPOSITORY;
		public IFW_GEO_TREE_REPOSITORY IFW_GEO_TREE_REPOSITORY
		 {
            get
            {
               if( iFW_GEO_TREE_REPOSITORY==null)
					iFW_GEO_TREE_REPOSITORY=new FW_GEO_TREE_REPOSITORY();
			   	return iFW_GEO_TREE_REPOSITORY;
            }
            set
            {
               iFW_GEO_TREE_REPOSITORY=value;
            }
        }

		 IFW_GEO_TREE_LEVEL_REPOSITORY iFW_GEO_TREE_LEVEL_REPOSITORY;
		public IFW_GEO_TREE_LEVEL_REPOSITORY IFW_GEO_TREE_LEVEL_REPOSITORY
		 {
            get
            {
               if( iFW_GEO_TREE_LEVEL_REPOSITORY==null)
					iFW_GEO_TREE_LEVEL_REPOSITORY=new FW_GEO_TREE_LEVEL_REPOSITORY();
			   	return iFW_GEO_TREE_LEVEL_REPOSITORY;
            }
            set
            {
               iFW_GEO_TREE_LEVEL_REPOSITORY=value;
            }
        }

		 IFW_MODULE_REPOSITORY iFW_MODULE_REPOSITORY;
		public IFW_MODULE_REPOSITORY IFW_MODULE_REPOSITORY
		 {
            get
            {
               if( iFW_MODULE_REPOSITORY==null)
					iFW_MODULE_REPOSITORY=new FW_MODULE_REPOSITORY();
			   	return iFW_MODULE_REPOSITORY;
            }
            set
            {
               iFW_MODULE_REPOSITORY=value;
            }
        }

		 IFW_MODULEPERMISSION_REPOSITORY iFW_MODULEPERMISSION_REPOSITORY;
		public IFW_MODULEPERMISSION_REPOSITORY IFW_MODULEPERMISSION_REPOSITORY
		 {
            get
            {
               if( iFW_MODULEPERMISSION_REPOSITORY==null)
					iFW_MODULEPERMISSION_REPOSITORY=new FW_MODULEPERMISSION_REPOSITORY();
			   	return iFW_MODULEPERMISSION_REPOSITORY;
            }
            set
            {
               iFW_MODULEPERMISSION_REPOSITORY=value;
            }
        }

		 IFW_OPERATELOG_REPOSITORY iFW_OPERATELOG_REPOSITORY;
		public IFW_OPERATELOG_REPOSITORY IFW_OPERATELOG_REPOSITORY
		 {
            get
            {
               if( iFW_OPERATELOG_REPOSITORY==null)
					iFW_OPERATELOG_REPOSITORY=new FW_OPERATELOG_REPOSITORY();
			   	return iFW_OPERATELOG_REPOSITORY;
            }
            set
            {
               iFW_OPERATELOG_REPOSITORY=value;
            }
        }

		 IFW_PERMISSION_REPOSITORY iFW_PERMISSION_REPOSITORY;
		public IFW_PERMISSION_REPOSITORY IFW_PERMISSION_REPOSITORY
		 {
            get
            {
               if( iFW_PERMISSION_REPOSITORY==null)
					iFW_PERMISSION_REPOSITORY=new FW_PERMISSION_REPOSITORY();
			   	return iFW_PERMISSION_REPOSITORY;
            }
            set
            {
               iFW_PERMISSION_REPOSITORY=value;
            }
        }

		 IFW_ROLE_REPOSITORY iFW_ROLE_REPOSITORY;
		public IFW_ROLE_REPOSITORY IFW_ROLE_REPOSITORY
		 {
            get
            {
               if( iFW_ROLE_REPOSITORY==null)
					iFW_ROLE_REPOSITORY=new FW_ROLE_REPOSITORY();
			   	return iFW_ROLE_REPOSITORY;
            }
            set
            {
               iFW_ROLE_REPOSITORY=value;
            }
        }

		 IFW_ROLEPERMISSION_REPOSITORY iFW_ROLEPERMISSION_REPOSITORY;
		public IFW_ROLEPERMISSION_REPOSITORY IFW_ROLEPERMISSION_REPOSITORY
		 {
            get
            {
               if( iFW_ROLEPERMISSION_REPOSITORY==null)
					iFW_ROLEPERMISSION_REPOSITORY=new FW_ROLEPERMISSION_REPOSITORY();
			   	return iFW_ROLEPERMISSION_REPOSITORY;
            }
            set
            {
               iFW_ROLEPERMISSION_REPOSITORY=value;
            }
        }

		 IFW_USER_REPOSITORY iFW_USER_REPOSITORY;
		public IFW_USER_REPOSITORY IFW_USER_REPOSITORY
		 {
            get
            {
               if( iFW_USER_REPOSITORY==null)
					iFW_USER_REPOSITORY=new FW_USER_REPOSITORY();
			   	return iFW_USER_REPOSITORY;
            }
            set
            {
               iFW_USER_REPOSITORY=value;
            }
        }

		 IFW_USER_ASSIGN_REPOSITORY iFW_USER_ASSIGN_REPOSITORY;
		public IFW_USER_ASSIGN_REPOSITORY IFW_USER_ASSIGN_REPOSITORY
		 {
            get
            {
               if( iFW_USER_ASSIGN_REPOSITORY==null)
					iFW_USER_ASSIGN_REPOSITORY=new FW_USER_ASSIGN_REPOSITORY();
			   	return iFW_USER_ASSIGN_REPOSITORY;
            }
            set
            {
               iFW_USER_ASSIGN_REPOSITORY=value;
            }
        }

		 IFW_USER_ROLE_REPOSITORY iFW_USER_ROLE_REPOSITORY;
		public IFW_USER_ROLE_REPOSITORY IFW_USER_ROLE_REPOSITORY
		 {
            get
            {
               if( iFW_USER_ROLE_REPOSITORY==null)
					iFW_USER_ROLE_REPOSITORY=new FW_USER_ROLE_REPOSITORY();
			   	return iFW_USER_ROLE_REPOSITORY;
            }
            set
            {
               iFW_USER_ROLE_REPOSITORY=value;
            }
        }

		 IJF_Order_REPOSITORY iJF_Order_REPOSITORY;
		public IJF_Order_REPOSITORY IJF_Order_REPOSITORY
		 {
            get
            {
               if( iJF_Order_REPOSITORY==null)
					iJF_Order_REPOSITORY=new JF_Order_REPOSITORY();
			   	return iJF_Order_REPOSITORY;
            }
            set
            {
               iJF_Order_REPOSITORY=value;
            }
        }

		 IJF_Product_REPOSITORY iJF_Product_REPOSITORY;
		public IJF_Product_REPOSITORY IJF_Product_REPOSITORY
		 {
            get
            {
               if( iJF_Product_REPOSITORY==null)
					iJF_Product_REPOSITORY=new JF_Product_REPOSITORY();
			   	return iJF_Product_REPOSITORY;
            }
            set
            {
               iJF_Product_REPOSITORY=value;
            }
        }

		 IMST_ARTICLE_REPOSITORY iMST_ARTICLE_REPOSITORY;
		public IMST_ARTICLE_REPOSITORY IMST_ARTICLE_REPOSITORY
		 {
            get
            {
               if( iMST_ARTICLE_REPOSITORY==null)
					iMST_ARTICLE_REPOSITORY=new MST_ARTICLE_REPOSITORY();
			   	return iMST_ARTICLE_REPOSITORY;
            }
            set
            {
               iMST_ARTICLE_REPOSITORY=value;
            }
        }

		 IMST_ATTACHMENTS_REPOSITORY iMST_ATTACHMENTS_REPOSITORY;
		public IMST_ATTACHMENTS_REPOSITORY IMST_ATTACHMENTS_REPOSITORY
		 {
            get
            {
               if( iMST_ATTACHMENTS_REPOSITORY==null)
					iMST_ATTACHMENTS_REPOSITORY=new MST_ATTACHMENTS_REPOSITORY();
			   	return iMST_ATTACHMENTS_REPOSITORY;
            }
            set
            {
               iMST_ATTACHMENTS_REPOSITORY=value;
            }
        }

		 IMST_CAR_REPOSITORY iMST_CAR_REPOSITORY;
		public IMST_CAR_REPOSITORY IMST_CAR_REPOSITORY
		 {
            get
            {
               if( iMST_CAR_REPOSITORY==null)
					iMST_CAR_REPOSITORY=new MST_CAR_REPOSITORY();
			   	return iMST_CAR_REPOSITORY;
            }
            set
            {
               iMST_CAR_REPOSITORY=value;
            }
        }

		 IMST_CATALOG_REPOSITORY iMST_CATALOG_REPOSITORY;
		public IMST_CATALOG_REPOSITORY IMST_CATALOG_REPOSITORY
		 {
            get
            {
               if( iMST_CATALOG_REPOSITORY==null)
					iMST_CATALOG_REPOSITORY=new MST_CATALOG_REPOSITORY();
			   	return iMST_CATALOG_REPOSITORY;
            }
            set
            {
               iMST_CATALOG_REPOSITORY=value;
            }
        }

		 IMST_CATEGORY_REPOSITORY iMST_CATEGORY_REPOSITORY;
		public IMST_CATEGORY_REPOSITORY IMST_CATEGORY_REPOSITORY
		 {
            get
            {
               if( iMST_CATEGORY_REPOSITORY==null)
					iMST_CATEGORY_REPOSITORY=new MST_CATEGORY_REPOSITORY();
			   	return iMST_CATEGORY_REPOSITORY;
            }
            set
            {
               iMST_CATEGORY_REPOSITORY=value;
            }
        }

		 IMST_COMPANY_REPOSITORY iMST_COMPANY_REPOSITORY;
		public IMST_COMPANY_REPOSITORY IMST_COMPANY_REPOSITORY
		 {
            get
            {
               if( iMST_COMPANY_REPOSITORY==null)
					iMST_COMPANY_REPOSITORY=new MST_COMPANY_REPOSITORY();
			   	return iMST_COMPANY_REPOSITORY;
            }
            set
            {
               iMST_COMPANY_REPOSITORY=value;
            }
        }

		 IMST_COMPANY_MEM_REPOSITORY iMST_COMPANY_MEM_REPOSITORY;
		public IMST_COMPANY_MEM_REPOSITORY IMST_COMPANY_MEM_REPOSITORY
		 {
            get
            {
               if( iMST_COMPANY_MEM_REPOSITORY==null)
					iMST_COMPANY_MEM_REPOSITORY=new MST_COMPANY_MEM_REPOSITORY();
			   	return iMST_COMPANY_MEM_REPOSITORY;
            }
            set
            {
               iMST_COMPANY_MEM_REPOSITORY=value;
            }
        }

		 IMST_MEMBER_REPOSITORY iMST_MEMBER_REPOSITORY;
		public IMST_MEMBER_REPOSITORY IMST_MEMBER_REPOSITORY
		 {
            get
            {
               if( iMST_MEMBER_REPOSITORY==null)
					iMST_MEMBER_REPOSITORY=new MST_MEMBER_REPOSITORY();
			   	return iMST_MEMBER_REPOSITORY;
            }
            set
            {
               iMST_MEMBER_REPOSITORY=value;
            }
        }

		 IMST_MUSTSELL_REPOSITORY iMST_MUSTSELL_REPOSITORY;
		public IMST_MUSTSELL_REPOSITORY IMST_MUSTSELL_REPOSITORY
		 {
            get
            {
               if( iMST_MUSTSELL_REPOSITORY==null)
					iMST_MUSTSELL_REPOSITORY=new MST_MUSTSELL_REPOSITORY();
			   	return iMST_MUSTSELL_REPOSITORY;
            }
            set
            {
               iMST_MUSTSELL_REPOSITORY=value;
            }
        }

		 IMST_MUSTSELL_DTL_REPOSITORY iMST_MUSTSELL_DTL_REPOSITORY;
		public IMST_MUSTSELL_DTL_REPOSITORY IMST_MUSTSELL_DTL_REPOSITORY
		 {
            get
            {
               if( iMST_MUSTSELL_DTL_REPOSITORY==null)
					iMST_MUSTSELL_DTL_REPOSITORY=new MST_MUSTSELL_DTL_REPOSITORY();
			   	return iMST_MUSTSELL_DTL_REPOSITORY;
            }
            set
            {
               iMST_MUSTSELL_DTL_REPOSITORY=value;
            }
        }

		 IMST_MUSTSELL_PRD_REPOSITORY iMST_MUSTSELL_PRD_REPOSITORY;
		public IMST_MUSTSELL_PRD_REPOSITORY IMST_MUSTSELL_PRD_REPOSITORY
		 {
            get
            {
               if( iMST_MUSTSELL_PRD_REPOSITORY==null)
					iMST_MUSTSELL_PRD_REPOSITORY=new MST_MUSTSELL_PRD_REPOSITORY();
			   	return iMST_MUSTSELL_PRD_REPOSITORY;
            }
            set
            {
               iMST_MUSTSELL_PRD_REPOSITORY=value;
            }
        }

		 IMST_POSITION_REPOSITORY iMST_POSITION_REPOSITORY;
		public IMST_POSITION_REPOSITORY IMST_POSITION_REPOSITORY
		 {
            get
            {
               if( iMST_POSITION_REPOSITORY==null)
					iMST_POSITION_REPOSITORY=new MST_POSITION_REPOSITORY();
			   	return iMST_POSITION_REPOSITORY;
            }
            set
            {
               iMST_POSITION_REPOSITORY=value;
            }
        }

		 IMST_PRD_REPOSITORY iMST_PRD_REPOSITORY;
		public IMST_PRD_REPOSITORY IMST_PRD_REPOSITORY
		 {
            get
            {
               if( iMST_PRD_REPOSITORY==null)
					iMST_PRD_REPOSITORY=new MST_PRD_REPOSITORY();
			   	return iMST_PRD_REPOSITORY;
            }
            set
            {
               iMST_PRD_REPOSITORY=value;
            }
        }

		 IMST_PRD_CATE_REPOSITORY iMST_PRD_CATE_REPOSITORY;
		public IMST_PRD_CATE_REPOSITORY IMST_PRD_CATE_REPOSITORY
		 {
            get
            {
               if( iMST_PRD_CATE_REPOSITORY==null)
					iMST_PRD_CATE_REPOSITORY=new MST_PRD_CATE_REPOSITORY();
			   	return iMST_PRD_CATE_REPOSITORY;
            }
            set
            {
               iMST_PRD_CATE_REPOSITORY=value;
            }
        }

		 IMST_PRD_IMG_REPOSITORY iMST_PRD_IMG_REPOSITORY;
		public IMST_PRD_IMG_REPOSITORY IMST_PRD_IMG_REPOSITORY
		 {
            get
            {
               if( iMST_PRD_IMG_REPOSITORY==null)
					iMST_PRD_IMG_REPOSITORY=new MST_PRD_IMG_REPOSITORY();
			   	return iMST_PRD_IMG_REPOSITORY;
            }
            set
            {
               iMST_PRD_IMG_REPOSITORY=value;
            }
        }

		 IMST_RESUME_REPOSITORY iMST_RESUME_REPOSITORY;
		public IMST_RESUME_REPOSITORY IMST_RESUME_REPOSITORY
		 {
            get
            {
               if( iMST_RESUME_REPOSITORY==null)
					iMST_RESUME_REPOSITORY=new MST_RESUME_REPOSITORY();
			   	return iMST_RESUME_REPOSITORY;
            }
            set
            {
               iMST_RESUME_REPOSITORY=value;
            }
        }

		 IMST_RESUME_DTL_REPOSITORY iMST_RESUME_DTL_REPOSITORY;
		public IMST_RESUME_DTL_REPOSITORY IMST_RESUME_DTL_REPOSITORY
		 {
            get
            {
               if( iMST_RESUME_DTL_REPOSITORY==null)
					iMST_RESUME_DTL_REPOSITORY=new MST_RESUME_DTL_REPOSITORY();
			   	return iMST_RESUME_DTL_REPOSITORY;
            }
            set
            {
               iMST_RESUME_DTL_REPOSITORY=value;
            }
        }

		 IMST_SUPPLIER_REPOSITORY iMST_SUPPLIER_REPOSITORY;
		public IMST_SUPPLIER_REPOSITORY IMST_SUPPLIER_REPOSITORY
		 {
            get
            {
               if( iMST_SUPPLIER_REPOSITORY==null)
					iMST_SUPPLIER_REPOSITORY=new MST_SUPPLIER_REPOSITORY();
			   	return iMST_SUPPLIER_REPOSITORY;
            }
            set
            {
               iMST_SUPPLIER_REPOSITORY=value;
            }
        }

		 ISET_COUNTRY_REPOSITORY iSET_COUNTRY_REPOSITORY;
		public ISET_COUNTRY_REPOSITORY ISET_COUNTRY_REPOSITORY
		 {
            get
            {
               if( iSET_COUNTRY_REPOSITORY==null)
					iSET_COUNTRY_REPOSITORY=new SET_COUNTRY_REPOSITORY();
			   	return iSET_COUNTRY_REPOSITORY;
            }
            set
            {
               iSET_COUNTRY_REPOSITORY=value;
            }
        }

		 ISET_NAVIGATION_ITEM_REPOSITORY iSET_NAVIGATION_ITEM_REPOSITORY;
		public ISET_NAVIGATION_ITEM_REPOSITORY ISET_NAVIGATION_ITEM_REPOSITORY
		 {
            get
            {
               if( iSET_NAVIGATION_ITEM_REPOSITORY==null)
					iSET_NAVIGATION_ITEM_REPOSITORY=new SET_NAVIGATION_ITEM_REPOSITORY();
			   	return iSET_NAVIGATION_ITEM_REPOSITORY;
            }
            set
            {
               iSET_NAVIGATION_ITEM_REPOSITORY=value;
            }
        }

		 ISET_REGION_REPOSITORY iSET_REGION_REPOSITORY;
		public ISET_REGION_REPOSITORY ISET_REGION_REPOSITORY
		 {
            get
            {
               if( iSET_REGION_REPOSITORY==null)
					iSET_REGION_REPOSITORY=new SET_REGION_REPOSITORY();
			   	return iSET_REGION_REPOSITORY;
            }
            set
            {
               iSET_REGION_REPOSITORY=value;
            }
        }

		 ISYS_REF_REPOSITORY iSYS_REF_REPOSITORY;
		public ISYS_REF_REPOSITORY ISYS_REF_REPOSITORY
		 {
            get
            {
               if( iSYS_REF_REPOSITORY==null)
					iSYS_REF_REPOSITORY=new SYS_REF_REPOSITORY();
			   	return iSYS_REF_REPOSITORY;
            }
            set
            {
               iSYS_REF_REPOSITORY=value;
            }
        }

		 ISYS_USERLOGIN_REPOSITORY iSYS_USERLOGIN_REPOSITORY;
		public ISYS_USERLOGIN_REPOSITORY ISYS_USERLOGIN_REPOSITORY
		 {
            get
            {
               if( iSYS_USERLOGIN_REPOSITORY==null)
					iSYS_USERLOGIN_REPOSITORY=new SYS_USERLOGIN_REPOSITORY();
			   	return iSYS_USERLOGIN_REPOSITORY;
            }
            set
            {
               iSYS_USERLOGIN_REPOSITORY=value;
            }
        }

		 ITG_Address_REPOSITORY iTG_Address_REPOSITORY;
		public ITG_Address_REPOSITORY ITG_Address_REPOSITORY
		 {
            get
            {
               if( iTG_Address_REPOSITORY==null)
					iTG_Address_REPOSITORY=new TG_Address_REPOSITORY();
			   	return iTG_Address_REPOSITORY;
            }
            set
            {
               iTG_Address_REPOSITORY=value;
            }
        }

		 ITG_BankCrad_REPOSITORY iTG_BankCrad_REPOSITORY;
		public ITG_BankCrad_REPOSITORY ITG_BankCrad_REPOSITORY
		 {
            get
            {
               if( iTG_BankCrad_REPOSITORY==null)
					iTG_BankCrad_REPOSITORY=new TG_BankCrad_REPOSITORY();
			   	return iTG_BankCrad_REPOSITORY;
            }
            set
            {
               iTG_BankCrad_REPOSITORY=value;
            }
        }

		 ITG_Car_REPOSITORY iTG_Car_REPOSITORY;
		public ITG_Car_REPOSITORY ITG_Car_REPOSITORY
		 {
            get
            {
               if( iTG_Car_REPOSITORY==null)
					iTG_Car_REPOSITORY=new TG_Car_REPOSITORY();
			   	return iTG_Car_REPOSITORY;
            }
            set
            {
               iTG_Car_REPOSITORY=value;
            }
        }

		 ITG_fenxiaoConfig_REPOSITORY iTG_fenxiaoConfig_REPOSITORY;
		public ITG_fenxiaoConfig_REPOSITORY ITG_fenxiaoConfig_REPOSITORY
		 {
            get
            {
               if( iTG_fenxiaoConfig_REPOSITORY==null)
					iTG_fenxiaoConfig_REPOSITORY=new TG_fenxiaoConfig_REPOSITORY();
			   	return iTG_fenxiaoConfig_REPOSITORY;
            }
            set
            {
               iTG_fenxiaoConfig_REPOSITORY=value;
            }
        }

		 ITG_jifenLog_REPOSITORY iTG_jifenLog_REPOSITORY;
		public ITG_jifenLog_REPOSITORY ITG_jifenLog_REPOSITORY
		 {
            get
            {
               if( iTG_jifenLog_REPOSITORY==null)
					iTG_jifenLog_REPOSITORY=new TG_jifenLog_REPOSITORY();
			   	return iTG_jifenLog_REPOSITORY;
            }
            set
            {
               iTG_jifenLog_REPOSITORY=value;
            }
        }

		 ITG_order_REPOSITORY iTG_order_REPOSITORY;
		public ITG_order_REPOSITORY ITG_order_REPOSITORY
		 {
            get
            {
               if( iTG_order_REPOSITORY==null)
					iTG_order_REPOSITORY=new TG_order_REPOSITORY();
			   	return iTG_order_REPOSITORY;
            }
            set
            {
               iTG_order_REPOSITORY=value;
            }
        }

		 ITG_pic_REPOSITORY iTG_pic_REPOSITORY;
		public ITG_pic_REPOSITORY ITG_pic_REPOSITORY
		 {
            get
            {
               if( iTG_pic_REPOSITORY==null)
					iTG_pic_REPOSITORY=new TG_pic_REPOSITORY();
			   	return iTG_pic_REPOSITORY;
            }
            set
            {
               iTG_pic_REPOSITORY=value;
            }
        }

		 ITG_product_REPOSITORY iTG_product_REPOSITORY;
		public ITG_product_REPOSITORY ITG_product_REPOSITORY
		 {
            get
            {
               if( iTG_product_REPOSITORY==null)
					iTG_product_REPOSITORY=new TG_product_REPOSITORY();
			   	return iTG_product_REPOSITORY;
            }
            set
            {
               iTG_product_REPOSITORY=value;
            }
        }

		 ITG_productBrand_REPOSITORY iTG_productBrand_REPOSITORY;
		public ITG_productBrand_REPOSITORY ITG_productBrand_REPOSITORY
		 {
            get
            {
               if( iTG_productBrand_REPOSITORY==null)
					iTG_productBrand_REPOSITORY=new TG_productBrand_REPOSITORY();
			   	return iTG_productBrand_REPOSITORY;
            }
            set
            {
               iTG_productBrand_REPOSITORY=value;
            }
        }

		 ITG_productCate_REPOSITORY iTG_productCate_REPOSITORY;
		public ITG_productCate_REPOSITORY ITG_productCate_REPOSITORY
		 {
            get
            {
               if( iTG_productCate_REPOSITORY==null)
					iTG_productCate_REPOSITORY=new TG_productCate_REPOSITORY();
			   	return iTG_productCate_REPOSITORY;
            }
            set
            {
               iTG_productCate_REPOSITORY=value;
            }
        }

		 ITG_productColor_REPOSITORY iTG_productColor_REPOSITORY;
		public ITG_productColor_REPOSITORY ITG_productColor_REPOSITORY
		 {
            get
            {
               if( iTG_productColor_REPOSITORY==null)
					iTG_productColor_REPOSITORY=new TG_productColor_REPOSITORY();
			   	return iTG_productColor_REPOSITORY;
            }
            set
            {
               iTG_productColor_REPOSITORY=value;
            }
        }

		 ITG_QD_REPOSITORY iTG_QD_REPOSITORY;
		public ITG_QD_REPOSITORY ITG_QD_REPOSITORY
		 {
            get
            {
               if( iTG_QD_REPOSITORY==null)
					iTG_QD_REPOSITORY=new TG_QD_REPOSITORY();
			   	return iTG_QD_REPOSITORY;
            }
            set
            {
               iTG_QD_REPOSITORY=value;
            }
        }

		 ITG_redPaperLog_REPOSITORY iTG_redPaperLog_REPOSITORY;
		public ITG_redPaperLog_REPOSITORY ITG_redPaperLog_REPOSITORY
		 {
            get
            {
               if( iTG_redPaperLog_REPOSITORY==null)
					iTG_redPaperLog_REPOSITORY=new TG_redPaperLog_REPOSITORY();
			   	return iTG_redPaperLog_REPOSITORY;
            }
            set
            {
               iTG_redPaperLog_REPOSITORY=value;
            }
        }

		 ITG_review_REPOSITORY iTG_review_REPOSITORY;
		public ITG_review_REPOSITORY ITG_review_REPOSITORY
		 {
            get
            {
               if( iTG_review_REPOSITORY==null)
					iTG_review_REPOSITORY=new TG_review_REPOSITORY();
			   	return iTG_review_REPOSITORY;
            }
            set
            {
               iTG_review_REPOSITORY=value;
            }
        }

		 ITG_SCproduct_REPOSITORY iTG_SCproduct_REPOSITORY;
		public ITG_SCproduct_REPOSITORY ITG_SCproduct_REPOSITORY
		 {
            get
            {
               if( iTG_SCproduct_REPOSITORY==null)
					iTG_SCproduct_REPOSITORY=new TG_SCproduct_REPOSITORY();
			   	return iTG_SCproduct_REPOSITORY;
            }
            set
            {
               iTG_SCproduct_REPOSITORY=value;
            }
        }

		 ITG_Thing_REPOSITORY iTG_Thing_REPOSITORY;
		public ITG_Thing_REPOSITORY ITG_Thing_REPOSITORY
		 {
            get
            {
               if( iTG_Thing_REPOSITORY==null)
					iTG_Thing_REPOSITORY=new TG_Thing_REPOSITORY();
			   	return iTG_Thing_REPOSITORY;
            }
            set
            {
               iTG_Thing_REPOSITORY=value;
            }
        }

		 ITG_transactionLog_REPOSITORY iTG_transactionLog_REPOSITORY;
		public ITG_transactionLog_REPOSITORY ITG_transactionLog_REPOSITORY
		 {
            get
            {
               if( iTG_transactionLog_REPOSITORY==null)
					iTG_transactionLog_REPOSITORY=new TG_transactionLog_REPOSITORY();
			   	return iTG_transactionLog_REPOSITORY;
            }
            set
            {
               iTG_transactionLog_REPOSITORY=value;
            }
        }

		 ITG_tuihuo_REPOSITORY iTG_tuihuo_REPOSITORY;
		public ITG_tuihuo_REPOSITORY ITG_tuihuo_REPOSITORY
		 {
            get
            {
               if( iTG_tuihuo_REPOSITORY==null)
					iTG_tuihuo_REPOSITORY=new TG_tuihuo_REPOSITORY();
			   	return iTG_tuihuo_REPOSITORY;
            }
            set
            {
               iTG_tuihuo_REPOSITORY=value;
            }
        }

		 ITG_TXmoney_REPOSITORY iTG_TXmoney_REPOSITORY;
		public ITG_TXmoney_REPOSITORY ITG_TXmoney_REPOSITORY
		 {
            get
            {
               if( iTG_TXmoney_REPOSITORY==null)
					iTG_TXmoney_REPOSITORY=new TG_TXmoney_REPOSITORY();
			   	return iTG_TXmoney_REPOSITORY;
            }
            set
            {
               iTG_TXmoney_REPOSITORY=value;
            }
        }

		 ITG_wuliu_REPOSITORY iTG_wuliu_REPOSITORY;
		public ITG_wuliu_REPOSITORY ITG_wuliu_REPOSITORY
		 {
            get
            {
               if( iTG_wuliu_REPOSITORY==null)
					iTG_wuliu_REPOSITORY=new TG_wuliu_REPOSITORY();
			   	return iTG_wuliu_REPOSITORY;
            }
            set
            {
               iTG_wuliu_REPOSITORY=value;
            }
        }

		 ITokenConfig_REPOSITORY iTokenConfig_REPOSITORY;
		public ITokenConfig_REPOSITORY ITokenConfig_REPOSITORY
		 {
            get
            {
               if( iTokenConfig_REPOSITORY==null)
					iTokenConfig_REPOSITORY=new TokenConfig_REPOSITORY();
			   	return iTokenConfig_REPOSITORY;
            }
            set
            {
               iTokenConfig_REPOSITORY=value;
            }
        }

		 IYX_Event_REPOSITORY iYX_Event_REPOSITORY;
		public IYX_Event_REPOSITORY IYX_Event_REPOSITORY
		 {
            get
            {
               if( iYX_Event_REPOSITORY==null)
					iYX_Event_REPOSITORY=new YX_Event_REPOSITORY();
			   	return iYX_Event_REPOSITORY;
            }
            set
            {
               iYX_Event_REPOSITORY=value;
            }
        }

		 IYX_image_REPOSITORY iYX_image_REPOSITORY;
		public IYX_image_REPOSITORY IYX_image_REPOSITORY
		 {
            get
            {
               if( iYX_image_REPOSITORY==null)
					iYX_image_REPOSITORY=new YX_image_REPOSITORY();
			   	return iYX_image_REPOSITORY;
            }
            set
            {
               iYX_image_REPOSITORY=value;
            }
        }

		 IYX_music_REPOSITORY iYX_music_REPOSITORY;
		public IYX_music_REPOSITORY IYX_music_REPOSITORY
		 {
            get
            {
               if( iYX_music_REPOSITORY==null)
					iYX_music_REPOSITORY=new YX_music_REPOSITORY();
			   	return iYX_music_REPOSITORY;
            }
            set
            {
               iYX_music_REPOSITORY=value;
            }
        }

		 IYX_news_REPOSITORY iYX_news_REPOSITORY;
		public IYX_news_REPOSITORY IYX_news_REPOSITORY
		 {
            get
            {
               if( iYX_news_REPOSITORY==null)
					iYX_news_REPOSITORY=new YX_news_REPOSITORY();
			   	return iYX_news_REPOSITORY;
            }
            set
            {
               iYX_news_REPOSITORY=value;
            }
        }

		 IYX_sysConfigs_REPOSITORY iYX_sysConfigs_REPOSITORY;
		public IYX_sysConfigs_REPOSITORY IYX_sysConfigs_REPOSITORY
		 {
            get
            {
               if( iYX_sysConfigs_REPOSITORY==null)
					iYX_sysConfigs_REPOSITORY=new YX_sysConfigs_REPOSITORY();
			   	return iYX_sysConfigs_REPOSITORY;
            }
            set
            {
               iYX_sysConfigs_REPOSITORY=value;
            }
        }

		 IYX_sysLog_REPOSITORY iYX_sysLog_REPOSITORY;
		public IYX_sysLog_REPOSITORY IYX_sysLog_REPOSITORY
		 {
            get
            {
               if( iYX_sysLog_REPOSITORY==null)
					iYX_sysLog_REPOSITORY=new YX_sysLog_REPOSITORY();
			   	return iYX_sysLog_REPOSITORY;
            }
            set
            {
               iYX_sysLog_REPOSITORY=value;
            }
        }

		 IYX_sysNews_REPOSITORY iYX_sysNews_REPOSITORY;
		public IYX_sysNews_REPOSITORY IYX_sysNews_REPOSITORY
		 {
            get
            {
               if( iYX_sysNews_REPOSITORY==null)
					iYX_sysNews_REPOSITORY=new YX_sysNews_REPOSITORY();
			   	return iYX_sysNews_REPOSITORY;
            }
            set
            {
               iYX_sysNews_REPOSITORY=value;
            }
        }

		 IYX_text_REPOSITORY iYX_text_REPOSITORY;
		public IYX_text_REPOSITORY IYX_text_REPOSITORY
		 {
            get
            {
               if( iYX_text_REPOSITORY==null)
					iYX_text_REPOSITORY=new YX_text_REPOSITORY();
			   	return iYX_text_REPOSITORY;
            }
            set
            {
               iYX_text_REPOSITORY=value;
            }
        }

		 IYX_video_REPOSITORY iYX_video_REPOSITORY;
		public IYX_video_REPOSITORY IYX_video_REPOSITORY
		 {
            get
            {
               if( iYX_video_REPOSITORY==null)
					iYX_video_REPOSITORY=new YX_video_REPOSITORY();
			   	return iYX_video_REPOSITORY;
            }
            set
            {
               iYX_video_REPOSITORY=value;
            }
        }

		 IYX_voice_REPOSITORY iYX_voice_REPOSITORY;
		public IYX_voice_REPOSITORY IYX_voice_REPOSITORY
		 {
            get
            {
               if( iYX_voice_REPOSITORY==null)
					iYX_voice_REPOSITORY=new YX_voice_REPOSITORY();
			   	return iYX_voice_REPOSITORY;
            }
            set
            {
               iYX_voice_REPOSITORY=value;
            }
        }

		 IYX_weiUser_REPOSITORY iYX_weiUser_REPOSITORY;
		public IYX_weiUser_REPOSITORY IYX_weiUser_REPOSITORY
		 {
            get
            {
               if( iYX_weiUser_REPOSITORY==null)
					iYX_weiUser_REPOSITORY=new YX_weiUser_REPOSITORY();
			   	return iYX_weiUser_REPOSITORY;
            }
            set
            {
               iYX_weiUser_REPOSITORY=value;
            }
        }

		 IYX_weiXinMenus_REPOSITORY iYX_weiXinMenus_REPOSITORY;
		public IYX_weiXinMenus_REPOSITORY IYX_weiXinMenus_REPOSITORY
		 {
            get
            {
               if( iYX_weiXinMenus_REPOSITORY==null)
					iYX_weiXinMenus_REPOSITORY=new YX_weiXinMenus_REPOSITORY();
			   	return iYX_weiXinMenus_REPOSITORY;
            }
            set
            {
               iYX_weiXinMenus_REPOSITORY=value;
            }
        }

   }
}