
 
 using IBLLService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLLService
{
	public partial class BLLSession
    {
		 IFW_AUDIT_RECORD_MANAGER iFW_AUDIT_RECORD_MANAGER;
		public IFW_AUDIT_RECORD_MANAGER IFW_AUDIT_RECORD_MANAGER
		 {
            get
            {
               if( iFW_AUDIT_RECORD_MANAGER==null)
					iFW_AUDIT_RECORD_MANAGER=new FW_AUDIT_RECORD_MANAGER();
			   	return iFW_AUDIT_RECORD_MANAGER;
            }
            set
            {
               iFW_AUDIT_RECORD_MANAGER=value;
            }
        }

		 IFW_MODULE_MANAGER iFW_MODULE_MANAGER;
		public IFW_MODULE_MANAGER IFW_MODULE_MANAGER
		 {
            get
            {
               if( iFW_MODULE_MANAGER==null)
					iFW_MODULE_MANAGER=new FW_MODULE_MANAGER();
			   	return iFW_MODULE_MANAGER;
            }
            set
            {
               iFW_MODULE_MANAGER=value;
            }
        }

		 IFW_MODULEPERMISSION_MANAGER iFW_MODULEPERMISSION_MANAGER;
		public IFW_MODULEPERMISSION_MANAGER IFW_MODULEPERMISSION_MANAGER
		 {
            get
            {
               if( iFW_MODULEPERMISSION_MANAGER==null)
					iFW_MODULEPERMISSION_MANAGER=new FW_MODULEPERMISSION_MANAGER();
			   	return iFW_MODULEPERMISSION_MANAGER;
            }
            set
            {
               iFW_MODULEPERMISSION_MANAGER=value;
            }
        }

		 IFW_OPERATELOG_MANAGER iFW_OPERATELOG_MANAGER;
		public IFW_OPERATELOG_MANAGER IFW_OPERATELOG_MANAGER
		 {
            get
            {
               if( iFW_OPERATELOG_MANAGER==null)
					iFW_OPERATELOG_MANAGER=new FW_OPERATELOG_MANAGER();
			   	return iFW_OPERATELOG_MANAGER;
            }
            set
            {
               iFW_OPERATELOG_MANAGER=value;
            }
        }

		 IFW_PERMISSION_MANAGER iFW_PERMISSION_MANAGER;
		public IFW_PERMISSION_MANAGER IFW_PERMISSION_MANAGER
		 {
            get
            {
               if( iFW_PERMISSION_MANAGER==null)
					iFW_PERMISSION_MANAGER=new FW_PERMISSION_MANAGER();
			   	return iFW_PERMISSION_MANAGER;
            }
            set
            {
               iFW_PERMISSION_MANAGER=value;
            }
        }

		 IFW_ROLE_MANAGER iFW_ROLE_MANAGER;
		public IFW_ROLE_MANAGER IFW_ROLE_MANAGER
		 {
            get
            {
               if( iFW_ROLE_MANAGER==null)
					iFW_ROLE_MANAGER=new FW_ROLE_MANAGER();
			   	return iFW_ROLE_MANAGER;
            }
            set
            {
               iFW_ROLE_MANAGER=value;
            }
        }

		 IFW_ROLEPERMISSION_MANAGER iFW_ROLEPERMISSION_MANAGER;
		public IFW_ROLEPERMISSION_MANAGER IFW_ROLEPERMISSION_MANAGER
		 {
            get
            {
               if( iFW_ROLEPERMISSION_MANAGER==null)
					iFW_ROLEPERMISSION_MANAGER=new FW_ROLEPERMISSION_MANAGER();
			   	return iFW_ROLEPERMISSION_MANAGER;
            }
            set
            {
               iFW_ROLEPERMISSION_MANAGER=value;
            }
        }

		 IFW_USER_MANAGER iFW_USER_MANAGER;
		public IFW_USER_MANAGER IFW_USER_MANAGER
		 {
            get
            {
               if( iFW_USER_MANAGER==null)
					iFW_USER_MANAGER=new FW_USER_MANAGER();
			   	return iFW_USER_MANAGER;
            }
            set
            {
               iFW_USER_MANAGER=value;
            }
        }

		 IFW_USER_ROLE_MANAGER iFW_USER_ROLE_MANAGER;
		public IFW_USER_ROLE_MANAGER IFW_USER_ROLE_MANAGER
		 {
            get
            {
               if( iFW_USER_ROLE_MANAGER==null)
					iFW_USER_ROLE_MANAGER=new FW_USER_ROLE_MANAGER();
			   	return iFW_USER_ROLE_MANAGER;
            }
            set
            {
               iFW_USER_ROLE_MANAGER=value;
            }
        }

		 IJF_Order_MANAGER iJF_Order_MANAGER;
		public IJF_Order_MANAGER IJF_Order_MANAGER
		 {
            get
            {
               if( iJF_Order_MANAGER==null)
					iJF_Order_MANAGER=new JF_Order_MANAGER();
			   	return iJF_Order_MANAGER;
            }
            set
            {
               iJF_Order_MANAGER=value;
            }
        }

		 IJF_Product_MANAGER iJF_Product_MANAGER;
		public IJF_Product_MANAGER IJF_Product_MANAGER
		 {
            get
            {
               if( iJF_Product_MANAGER==null)
					iJF_Product_MANAGER=new JF_Product_MANAGER();
			   	return iJF_Product_MANAGER;
            }
            set
            {
               iJF_Product_MANAGER=value;
            }
        }

		 IMST_ARTICLE_MANAGER iMST_ARTICLE_MANAGER;
		public IMST_ARTICLE_MANAGER IMST_ARTICLE_MANAGER
		 {
            get
            {
               if( iMST_ARTICLE_MANAGER==null)
					iMST_ARTICLE_MANAGER=new MST_ARTICLE_MANAGER();
			   	return iMST_ARTICLE_MANAGER;
            }
            set
            {
               iMST_ARTICLE_MANAGER=value;
            }
        }

		 IMST_ATTACHMENTS_MANAGER iMST_ATTACHMENTS_MANAGER;
		public IMST_ATTACHMENTS_MANAGER IMST_ATTACHMENTS_MANAGER
		 {
            get
            {
               if( iMST_ATTACHMENTS_MANAGER==null)
					iMST_ATTACHMENTS_MANAGER=new MST_ATTACHMENTS_MANAGER();
			   	return iMST_ATTACHMENTS_MANAGER;
            }
            set
            {
               iMST_ATTACHMENTS_MANAGER=value;
            }
        }

		 IMST_CAR_MANAGER iMST_CAR_MANAGER;
		public IMST_CAR_MANAGER IMST_CAR_MANAGER
		 {
            get
            {
               if( iMST_CAR_MANAGER==null)
					iMST_CAR_MANAGER=new MST_CAR_MANAGER();
			   	return iMST_CAR_MANAGER;
            }
            set
            {
               iMST_CAR_MANAGER=value;
            }
        }

		 IMST_CATALOG_MANAGER iMST_CATALOG_MANAGER;
		public IMST_CATALOG_MANAGER IMST_CATALOG_MANAGER
		 {
            get
            {
               if( iMST_CATALOG_MANAGER==null)
					iMST_CATALOG_MANAGER=new MST_CATALOG_MANAGER();
			   	return iMST_CATALOG_MANAGER;
            }
            set
            {
               iMST_CATALOG_MANAGER=value;
            }
        }

		 IMST_CATEGORY_MANAGER iMST_CATEGORY_MANAGER;
		public IMST_CATEGORY_MANAGER IMST_CATEGORY_MANAGER
		 {
            get
            {
               if( iMST_CATEGORY_MANAGER==null)
					iMST_CATEGORY_MANAGER=new MST_CATEGORY_MANAGER();
			   	return iMST_CATEGORY_MANAGER;
            }
            set
            {
               iMST_CATEGORY_MANAGER=value;
            }
        }

		 IMST_COMPANY_MANAGER iMST_COMPANY_MANAGER;
		public IMST_COMPANY_MANAGER IMST_COMPANY_MANAGER
		 {
            get
            {
               if( iMST_COMPANY_MANAGER==null)
					iMST_COMPANY_MANAGER=new MST_COMPANY_MANAGER();
			   	return iMST_COMPANY_MANAGER;
            }
            set
            {
               iMST_COMPANY_MANAGER=value;
            }
        }

		 IMST_COMPANY_MEM_MANAGER iMST_COMPANY_MEM_MANAGER;
		public IMST_COMPANY_MEM_MANAGER IMST_COMPANY_MEM_MANAGER
		 {
            get
            {
               if( iMST_COMPANY_MEM_MANAGER==null)
					iMST_COMPANY_MEM_MANAGER=new MST_COMPANY_MEM_MANAGER();
			   	return iMST_COMPANY_MEM_MANAGER;
            }
            set
            {
               iMST_COMPANY_MEM_MANAGER=value;
            }
        }

		 IMST_MEMBER_MANAGER iMST_MEMBER_MANAGER;
		public IMST_MEMBER_MANAGER IMST_MEMBER_MANAGER
		 {
            get
            {
               if( iMST_MEMBER_MANAGER==null)
					iMST_MEMBER_MANAGER=new MST_MEMBER_MANAGER();
			   	return iMST_MEMBER_MANAGER;
            }
            set
            {
               iMST_MEMBER_MANAGER=value;
            }
        }

		 IMST_POSITION_MANAGER iMST_POSITION_MANAGER;
		public IMST_POSITION_MANAGER IMST_POSITION_MANAGER
		 {
            get
            {
               if( iMST_POSITION_MANAGER==null)
					iMST_POSITION_MANAGER=new MST_POSITION_MANAGER();
			   	return iMST_POSITION_MANAGER;
            }
            set
            {
               iMST_POSITION_MANAGER=value;
            }
        }

		 IMST_PRD_MANAGER iMST_PRD_MANAGER;
		public IMST_PRD_MANAGER IMST_PRD_MANAGER
		 {
            get
            {
               if( iMST_PRD_MANAGER==null)
					iMST_PRD_MANAGER=new MST_PRD_MANAGER();
			   	return iMST_PRD_MANAGER;
            }
            set
            {
               iMST_PRD_MANAGER=value;
            }
        }

		 IMST_PRD_CATE_MANAGER iMST_PRD_CATE_MANAGER;
		public IMST_PRD_CATE_MANAGER IMST_PRD_CATE_MANAGER
		 {
            get
            {
               if( iMST_PRD_CATE_MANAGER==null)
					iMST_PRD_CATE_MANAGER=new MST_PRD_CATE_MANAGER();
			   	return iMST_PRD_CATE_MANAGER;
            }
            set
            {
               iMST_PRD_CATE_MANAGER=value;
            }
        }

		 IMST_PRD_IMG_MANAGER iMST_PRD_IMG_MANAGER;
		public IMST_PRD_IMG_MANAGER IMST_PRD_IMG_MANAGER
		 {
            get
            {
               if( iMST_PRD_IMG_MANAGER==null)
					iMST_PRD_IMG_MANAGER=new MST_PRD_IMG_MANAGER();
			   	return iMST_PRD_IMG_MANAGER;
            }
            set
            {
               iMST_PRD_IMG_MANAGER=value;
            }
        }

		 IMST_RESUME_MANAGER iMST_RESUME_MANAGER;
		public IMST_RESUME_MANAGER IMST_RESUME_MANAGER
		 {
            get
            {
               if( iMST_RESUME_MANAGER==null)
					iMST_RESUME_MANAGER=new MST_RESUME_MANAGER();
			   	return iMST_RESUME_MANAGER;
            }
            set
            {
               iMST_RESUME_MANAGER=value;
            }
        }

		 IMST_RESUME_DTL_MANAGER iMST_RESUME_DTL_MANAGER;
		public IMST_RESUME_DTL_MANAGER IMST_RESUME_DTL_MANAGER
		 {
            get
            {
               if( iMST_RESUME_DTL_MANAGER==null)
					iMST_RESUME_DTL_MANAGER=new MST_RESUME_DTL_MANAGER();
			   	return iMST_RESUME_DTL_MANAGER;
            }
            set
            {
               iMST_RESUME_DTL_MANAGER=value;
            }
        }

		 IMST_SUPPLIER_MANAGER iMST_SUPPLIER_MANAGER;
		public IMST_SUPPLIER_MANAGER IMST_SUPPLIER_MANAGER
		 {
            get
            {
               if( iMST_SUPPLIER_MANAGER==null)
					iMST_SUPPLIER_MANAGER=new MST_SUPPLIER_MANAGER();
			   	return iMST_SUPPLIER_MANAGER;
            }
            set
            {
               iMST_SUPPLIER_MANAGER=value;
            }
        }

		 ISET_COUNTRY_MANAGER iSET_COUNTRY_MANAGER;
		public ISET_COUNTRY_MANAGER ISET_COUNTRY_MANAGER
		 {
            get
            {
               if( iSET_COUNTRY_MANAGER==null)
					iSET_COUNTRY_MANAGER=new SET_COUNTRY_MANAGER();
			   	return iSET_COUNTRY_MANAGER;
            }
            set
            {
               iSET_COUNTRY_MANAGER=value;
            }
        }

		 ISET_NAVIGATION_ITEM_MANAGER iSET_NAVIGATION_ITEM_MANAGER;
		public ISET_NAVIGATION_ITEM_MANAGER ISET_NAVIGATION_ITEM_MANAGER
		 {
            get
            {
               if( iSET_NAVIGATION_ITEM_MANAGER==null)
					iSET_NAVIGATION_ITEM_MANAGER=new SET_NAVIGATION_ITEM_MANAGER();
			   	return iSET_NAVIGATION_ITEM_MANAGER;
            }
            set
            {
               iSET_NAVIGATION_ITEM_MANAGER=value;
            }
        }

		 ISET_REGION_MANAGER iSET_REGION_MANAGER;
		public ISET_REGION_MANAGER ISET_REGION_MANAGER
		 {
            get
            {
               if( iSET_REGION_MANAGER==null)
					iSET_REGION_MANAGER=new SET_REGION_MANAGER();
			   	return iSET_REGION_MANAGER;
            }
            set
            {
               iSET_REGION_MANAGER=value;
            }
        }

		 ISYS_REF_MANAGER iSYS_REF_MANAGER;
		public ISYS_REF_MANAGER ISYS_REF_MANAGER
		 {
            get
            {
               if( iSYS_REF_MANAGER==null)
					iSYS_REF_MANAGER=new SYS_REF_MANAGER();
			   	return iSYS_REF_MANAGER;
            }
            set
            {
               iSYS_REF_MANAGER=value;
            }
        }

		 ITG_Address_MANAGER iTG_Address_MANAGER;
		public ITG_Address_MANAGER ITG_Address_MANAGER
		 {
            get
            {
               if( iTG_Address_MANAGER==null)
					iTG_Address_MANAGER=new TG_Address_MANAGER();
			   	return iTG_Address_MANAGER;
            }
            set
            {
               iTG_Address_MANAGER=value;
            }
        }

		 ITG_BankCrad_MANAGER iTG_BankCrad_MANAGER;
		public ITG_BankCrad_MANAGER ITG_BankCrad_MANAGER
		 {
            get
            {
               if( iTG_BankCrad_MANAGER==null)
					iTG_BankCrad_MANAGER=new TG_BankCrad_MANAGER();
			   	return iTG_BankCrad_MANAGER;
            }
            set
            {
               iTG_BankCrad_MANAGER=value;
            }
        }

		 ITG_Car_MANAGER iTG_Car_MANAGER;
		public ITG_Car_MANAGER ITG_Car_MANAGER
		 {
            get
            {
               if( iTG_Car_MANAGER==null)
					iTG_Car_MANAGER=new TG_Car_MANAGER();
			   	return iTG_Car_MANAGER;
            }
            set
            {
               iTG_Car_MANAGER=value;
            }
        }

		 ITG_fenxiaoConfig_MANAGER iTG_fenxiaoConfig_MANAGER;
		public ITG_fenxiaoConfig_MANAGER ITG_fenxiaoConfig_MANAGER
		 {
            get
            {
               if( iTG_fenxiaoConfig_MANAGER==null)
					iTG_fenxiaoConfig_MANAGER=new TG_fenxiaoConfig_MANAGER();
			   	return iTG_fenxiaoConfig_MANAGER;
            }
            set
            {
               iTG_fenxiaoConfig_MANAGER=value;
            }
        }

		 ITG_jifenLog_MANAGER iTG_jifenLog_MANAGER;
		public ITG_jifenLog_MANAGER ITG_jifenLog_MANAGER
		 {
            get
            {
               if( iTG_jifenLog_MANAGER==null)
					iTG_jifenLog_MANAGER=new TG_jifenLog_MANAGER();
			   	return iTG_jifenLog_MANAGER;
            }
            set
            {
               iTG_jifenLog_MANAGER=value;
            }
        }

		 ITG_order_MANAGER iTG_order_MANAGER;
		public ITG_order_MANAGER ITG_order_MANAGER
		 {
            get
            {
               if( iTG_order_MANAGER==null)
					iTG_order_MANAGER=new TG_order_MANAGER();
			   	return iTG_order_MANAGER;
            }
            set
            {
               iTG_order_MANAGER=value;
            }
        }

		 ITG_pic_MANAGER iTG_pic_MANAGER;
		public ITG_pic_MANAGER ITG_pic_MANAGER
		 {
            get
            {
               if( iTG_pic_MANAGER==null)
					iTG_pic_MANAGER=new TG_pic_MANAGER();
			   	return iTG_pic_MANAGER;
            }
            set
            {
               iTG_pic_MANAGER=value;
            }
        }

		 ITG_product_MANAGER iTG_product_MANAGER;
		public ITG_product_MANAGER ITG_product_MANAGER
		 {
            get
            {
               if( iTG_product_MANAGER==null)
					iTG_product_MANAGER=new TG_product_MANAGER();
			   	return iTG_product_MANAGER;
            }
            set
            {
               iTG_product_MANAGER=value;
            }
        }

		 ITG_productBrand_MANAGER iTG_productBrand_MANAGER;
		public ITG_productBrand_MANAGER ITG_productBrand_MANAGER
		 {
            get
            {
               if( iTG_productBrand_MANAGER==null)
					iTG_productBrand_MANAGER=new TG_productBrand_MANAGER();
			   	return iTG_productBrand_MANAGER;
            }
            set
            {
               iTG_productBrand_MANAGER=value;
            }
        }

		 ITG_productCate_MANAGER iTG_productCate_MANAGER;
		public ITG_productCate_MANAGER ITG_productCate_MANAGER
		 {
            get
            {
               if( iTG_productCate_MANAGER==null)
					iTG_productCate_MANAGER=new TG_productCate_MANAGER();
			   	return iTG_productCate_MANAGER;
            }
            set
            {
               iTG_productCate_MANAGER=value;
            }
        }

		 ITG_productColor_MANAGER iTG_productColor_MANAGER;
		public ITG_productColor_MANAGER ITG_productColor_MANAGER
		 {
            get
            {
               if( iTG_productColor_MANAGER==null)
					iTG_productColor_MANAGER=new TG_productColor_MANAGER();
			   	return iTG_productColor_MANAGER;
            }
            set
            {
               iTG_productColor_MANAGER=value;
            }
        }

		 ITG_QD_MANAGER iTG_QD_MANAGER;
		public ITG_QD_MANAGER ITG_QD_MANAGER
		 {
            get
            {
               if( iTG_QD_MANAGER==null)
					iTG_QD_MANAGER=new TG_QD_MANAGER();
			   	return iTG_QD_MANAGER;
            }
            set
            {
               iTG_QD_MANAGER=value;
            }
        }

		 ITG_redPaperLog_MANAGER iTG_redPaperLog_MANAGER;
		public ITG_redPaperLog_MANAGER ITG_redPaperLog_MANAGER
		 {
            get
            {
               if( iTG_redPaperLog_MANAGER==null)
					iTG_redPaperLog_MANAGER=new TG_redPaperLog_MANAGER();
			   	return iTG_redPaperLog_MANAGER;
            }
            set
            {
               iTG_redPaperLog_MANAGER=value;
            }
        }

		 ITG_review_MANAGER iTG_review_MANAGER;
		public ITG_review_MANAGER ITG_review_MANAGER
		 {
            get
            {
               if( iTG_review_MANAGER==null)
					iTG_review_MANAGER=new TG_review_MANAGER();
			   	return iTG_review_MANAGER;
            }
            set
            {
               iTG_review_MANAGER=value;
            }
        }

		 ITG_SCproduct_MANAGER iTG_SCproduct_MANAGER;
		public ITG_SCproduct_MANAGER ITG_SCproduct_MANAGER
		 {
            get
            {
               if( iTG_SCproduct_MANAGER==null)
					iTG_SCproduct_MANAGER=new TG_SCproduct_MANAGER();
			   	return iTG_SCproduct_MANAGER;
            }
            set
            {
               iTG_SCproduct_MANAGER=value;
            }
        }

		 ITG_Thing_MANAGER iTG_Thing_MANAGER;
		public ITG_Thing_MANAGER ITG_Thing_MANAGER
		 {
            get
            {
               if( iTG_Thing_MANAGER==null)
					iTG_Thing_MANAGER=new TG_Thing_MANAGER();
			   	return iTG_Thing_MANAGER;
            }
            set
            {
               iTG_Thing_MANAGER=value;
            }
        }

		 ITG_transactionLog_MANAGER iTG_transactionLog_MANAGER;
		public ITG_transactionLog_MANAGER ITG_transactionLog_MANAGER
		 {
            get
            {
               if( iTG_transactionLog_MANAGER==null)
					iTG_transactionLog_MANAGER=new TG_transactionLog_MANAGER();
			   	return iTG_transactionLog_MANAGER;
            }
            set
            {
               iTG_transactionLog_MANAGER=value;
            }
        }

		 ITG_tuihuo_MANAGER iTG_tuihuo_MANAGER;
		public ITG_tuihuo_MANAGER ITG_tuihuo_MANAGER
		 {
            get
            {
               if( iTG_tuihuo_MANAGER==null)
					iTG_tuihuo_MANAGER=new TG_tuihuo_MANAGER();
			   	return iTG_tuihuo_MANAGER;
            }
            set
            {
               iTG_tuihuo_MANAGER=value;
            }
        }

		 ITG_TXmoney_MANAGER iTG_TXmoney_MANAGER;
		public ITG_TXmoney_MANAGER ITG_TXmoney_MANAGER
		 {
            get
            {
               if( iTG_TXmoney_MANAGER==null)
					iTG_TXmoney_MANAGER=new TG_TXmoney_MANAGER();
			   	return iTG_TXmoney_MANAGER;
            }
            set
            {
               iTG_TXmoney_MANAGER=value;
            }
        }

		 ITG_wuliu_MANAGER iTG_wuliu_MANAGER;
		public ITG_wuliu_MANAGER ITG_wuliu_MANAGER
		 {
            get
            {
               if( iTG_wuliu_MANAGER==null)
					iTG_wuliu_MANAGER=new TG_wuliu_MANAGER();
			   	return iTG_wuliu_MANAGER;
            }
            set
            {
               iTG_wuliu_MANAGER=value;
            }
        }

		 ITokenConfig_MANAGER iTokenConfig_MANAGER;
		public ITokenConfig_MANAGER ITokenConfig_MANAGER
		 {
            get
            {
               if( iTokenConfig_MANAGER==null)
					iTokenConfig_MANAGER=new TokenConfig_MANAGER();
			   	return iTokenConfig_MANAGER;
            }
            set
            {
               iTokenConfig_MANAGER=value;
            }
        }

		 IYX_Event_MANAGER iYX_Event_MANAGER;
		public IYX_Event_MANAGER IYX_Event_MANAGER
		 {
            get
            {
               if( iYX_Event_MANAGER==null)
					iYX_Event_MANAGER=new YX_Event_MANAGER();
			   	return iYX_Event_MANAGER;
            }
            set
            {
               iYX_Event_MANAGER=value;
            }
        }

		 IYX_image_MANAGER iYX_image_MANAGER;
		public IYX_image_MANAGER IYX_image_MANAGER
		 {
            get
            {
               if( iYX_image_MANAGER==null)
					iYX_image_MANAGER=new YX_image_MANAGER();
			   	return iYX_image_MANAGER;
            }
            set
            {
               iYX_image_MANAGER=value;
            }
        }

		 IYX_music_MANAGER iYX_music_MANAGER;
		public IYX_music_MANAGER IYX_music_MANAGER
		 {
            get
            {
               if( iYX_music_MANAGER==null)
					iYX_music_MANAGER=new YX_music_MANAGER();
			   	return iYX_music_MANAGER;
            }
            set
            {
               iYX_music_MANAGER=value;
            }
        }

		 IYX_news_MANAGER iYX_news_MANAGER;
		public IYX_news_MANAGER IYX_news_MANAGER
		 {
            get
            {
               if( iYX_news_MANAGER==null)
					iYX_news_MANAGER=new YX_news_MANAGER();
			   	return iYX_news_MANAGER;
            }
            set
            {
               iYX_news_MANAGER=value;
            }
        }

		 IYX_sysConfigs_MANAGER iYX_sysConfigs_MANAGER;
		public IYX_sysConfigs_MANAGER IYX_sysConfigs_MANAGER
		 {
            get
            {
               if( iYX_sysConfigs_MANAGER==null)
					iYX_sysConfigs_MANAGER=new YX_sysConfigs_MANAGER();
			   	return iYX_sysConfigs_MANAGER;
            }
            set
            {
               iYX_sysConfigs_MANAGER=value;
            }
        }

		 IYX_sysLog_MANAGER iYX_sysLog_MANAGER;
		public IYX_sysLog_MANAGER IYX_sysLog_MANAGER
		 {
            get
            {
               if( iYX_sysLog_MANAGER==null)
					iYX_sysLog_MANAGER=new YX_sysLog_MANAGER();
			   	return iYX_sysLog_MANAGER;
            }
            set
            {
               iYX_sysLog_MANAGER=value;
            }
        }

		 IYX_sysNews_MANAGER iYX_sysNews_MANAGER;
		public IYX_sysNews_MANAGER IYX_sysNews_MANAGER
		 {
            get
            {
               if( iYX_sysNews_MANAGER==null)
					iYX_sysNews_MANAGER=new YX_sysNews_MANAGER();
			   	return iYX_sysNews_MANAGER;
            }
            set
            {
               iYX_sysNews_MANAGER=value;
            }
        }

		 IYX_text_MANAGER iYX_text_MANAGER;
		public IYX_text_MANAGER IYX_text_MANAGER
		 {
            get
            {
               if( iYX_text_MANAGER==null)
					iYX_text_MANAGER=new YX_text_MANAGER();
			   	return iYX_text_MANAGER;
            }
            set
            {
               iYX_text_MANAGER=value;
            }
        }

		 IYX_video_MANAGER iYX_video_MANAGER;
		public IYX_video_MANAGER IYX_video_MANAGER
		 {
            get
            {
               if( iYX_video_MANAGER==null)
					iYX_video_MANAGER=new YX_video_MANAGER();
			   	return iYX_video_MANAGER;
            }
            set
            {
               iYX_video_MANAGER=value;
            }
        }

		 IYX_voice_MANAGER iYX_voice_MANAGER;
		public IYX_voice_MANAGER IYX_voice_MANAGER
		 {
            get
            {
               if( iYX_voice_MANAGER==null)
					iYX_voice_MANAGER=new YX_voice_MANAGER();
			   	return iYX_voice_MANAGER;
            }
            set
            {
               iYX_voice_MANAGER=value;
            }
        }

		 IYX_weiUser_MANAGER iYX_weiUser_MANAGER;
		public IYX_weiUser_MANAGER IYX_weiUser_MANAGER
		 {
            get
            {
               if( iYX_weiUser_MANAGER==null)
					iYX_weiUser_MANAGER=new YX_weiUser_MANAGER();
			   	return iYX_weiUser_MANAGER;
            }
            set
            {
               iYX_weiUser_MANAGER=value;
            }
        }

		 IYX_weiXinMenus_MANAGER iYX_weiXinMenus_MANAGER;
		public IYX_weiXinMenus_MANAGER IYX_weiXinMenus_MANAGER
		 {
            get
            {
               if( iYX_weiXinMenus_MANAGER==null)
					iYX_weiXinMenus_MANAGER=new YX_weiXinMenus_MANAGER();
			   	return iYX_weiXinMenus_MANAGER;
            }
            set
            {
               iYX_weiXinMenus_MANAGER=value;
            }
        }

   }
}