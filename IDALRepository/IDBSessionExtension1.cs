﻿
 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDALRepository
{
	public partial interface IDBSession
    {
		IFW_AUDIT_RECORD_REPOSITORY IFW_AUDIT_RECORD_REPOSITORY {get;set;}

		IFW_MODULE_REPOSITORY IFW_MODULE_REPOSITORY {get;set;}

		IFW_MODULEPERMISSION_REPOSITORY IFW_MODULEPERMISSION_REPOSITORY {get;set;}

		IFW_OPERATELOG_REPOSITORY IFW_OPERATELOG_REPOSITORY {get;set;}

		IFW_PERMISSION_REPOSITORY IFW_PERMISSION_REPOSITORY {get;set;}

		IFW_ROLE_REPOSITORY IFW_ROLE_REPOSITORY {get;set;}

		IFW_ROLEPERMISSION_REPOSITORY IFW_ROLEPERMISSION_REPOSITORY {get;set;}

		IFW_USER_REPOSITORY IFW_USER_REPOSITORY {get;set;}

		IFW_USER_ROLE_REPOSITORY IFW_USER_ROLE_REPOSITORY {get;set;}

		IJF_Order_REPOSITORY IJF_Order_REPOSITORY {get;set;}

		IJF_Product_REPOSITORY IJF_Product_REPOSITORY {get;set;}

		IMST_ARTICLE_REPOSITORY IMST_ARTICLE_REPOSITORY {get;set;}

		IMST_ATTACHMENTS_REPOSITORY IMST_ATTACHMENTS_REPOSITORY {get;set;}

		IMST_CAR_REPOSITORY IMST_CAR_REPOSITORY {get;set;}

		IMST_CATALOG_REPOSITORY IMST_CATALOG_REPOSITORY {get;set;}

		IMST_CATEGORY_REPOSITORY IMST_CATEGORY_REPOSITORY {get;set;}

		IMST_COMPANY_REPOSITORY IMST_COMPANY_REPOSITORY {get;set;}

		IMST_COMPANY_MEM_REPOSITORY IMST_COMPANY_MEM_REPOSITORY {get;set;}

		IMST_MEMBER_REPOSITORY IMST_MEMBER_REPOSITORY {get;set;}

		IMST_POSITION_REPOSITORY IMST_POSITION_REPOSITORY {get;set;}

		IMST_PRD_REPOSITORY IMST_PRD_REPOSITORY {get;set;}

		IMST_PRD_CATE_REPOSITORY IMST_PRD_CATE_REPOSITORY {get;set;}

		IMST_PRD_IMG_REPOSITORY IMST_PRD_IMG_REPOSITORY {get;set;}

		IMST_RESUME_REPOSITORY IMST_RESUME_REPOSITORY {get;set;}

		IMST_RESUME_DTL_REPOSITORY IMST_RESUME_DTL_REPOSITORY {get;set;}

		IMST_SUPPLIER_REPOSITORY IMST_SUPPLIER_REPOSITORY {get;set;}

		ISET_COUNTRY_REPOSITORY ISET_COUNTRY_REPOSITORY {get;set;}

		ISET_NAVIGATION_ITEM_REPOSITORY ISET_NAVIGATION_ITEM_REPOSITORY {get;set;}

		ISET_REGION_REPOSITORY ISET_REGION_REPOSITORY {get;set;}

		ISYS_REF_REPOSITORY ISYS_REF_REPOSITORY {get;set;}

		ITG_Address_REPOSITORY ITG_Address_REPOSITORY {get;set;}

		ITG_BankCrad_REPOSITORY ITG_BankCrad_REPOSITORY {get;set;}

		ITG_Car_REPOSITORY ITG_Car_REPOSITORY {get;set;}

		ITG_fenxiaoConfig_REPOSITORY ITG_fenxiaoConfig_REPOSITORY {get;set;}

		ITG_jifenLog_REPOSITORY ITG_jifenLog_REPOSITORY {get;set;}

		ITG_order_REPOSITORY ITG_order_REPOSITORY {get;set;}

		ITG_pic_REPOSITORY ITG_pic_REPOSITORY {get;set;}

		ITG_product_REPOSITORY ITG_product_REPOSITORY {get;set;}

		ITG_productBrand_REPOSITORY ITG_productBrand_REPOSITORY {get;set;}

		ITG_productCate_REPOSITORY ITG_productCate_REPOSITORY {get;set;}

		ITG_productColor_REPOSITORY ITG_productColor_REPOSITORY {get;set;}

		ITG_QD_REPOSITORY ITG_QD_REPOSITORY {get;set;}

		ITG_redPaperLog_REPOSITORY ITG_redPaperLog_REPOSITORY {get;set;}

		ITG_review_REPOSITORY ITG_review_REPOSITORY {get;set;}

		ITG_SCproduct_REPOSITORY ITG_SCproduct_REPOSITORY {get;set;}

		ITG_Thing_REPOSITORY ITG_Thing_REPOSITORY {get;set;}

		ITG_transactionLog_REPOSITORY ITG_transactionLog_REPOSITORY {get;set;}

		ITG_tuihuo_REPOSITORY ITG_tuihuo_REPOSITORY {get;set;}

		ITG_TXmoney_REPOSITORY ITG_TXmoney_REPOSITORY {get;set;}

		ITG_wuliu_REPOSITORY ITG_wuliu_REPOSITORY {get;set;}

		ITokenConfig_REPOSITORY ITokenConfig_REPOSITORY {get;set;}

		IYX_Event_REPOSITORY IYX_Event_REPOSITORY {get;set;}

		IYX_image_REPOSITORY IYX_image_REPOSITORY {get;set;}

		IYX_music_REPOSITORY IYX_music_REPOSITORY {get;set;}

		IYX_news_REPOSITORY IYX_news_REPOSITORY {get;set;}

		IYX_sysConfigs_REPOSITORY IYX_sysConfigs_REPOSITORY {get;set;}

		IYX_sysLog_REPOSITORY IYX_sysLog_REPOSITORY {get;set;}

		IYX_sysNews_REPOSITORY IYX_sysNews_REPOSITORY {get;set;}

		IYX_text_REPOSITORY IYX_text_REPOSITORY {get;set;}

		IYX_video_REPOSITORY IYX_video_REPOSITORY {get;set;}

		IYX_voice_REPOSITORY IYX_voice_REPOSITORY {get;set;}

		IYX_weiUser_REPOSITORY IYX_weiUser_REPOSITORY {get;set;}

		IYX_weiXinMenus_REPOSITORY IYX_weiXinMenus_REPOSITORY {get;set;}

   }
}