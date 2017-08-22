 
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDALRepository
{
	public partial interface IFW_AUDIT_RECORD_REPOSITORY: IBaseDALRepository<MODEL.FW_AUDIT_RECORD>
    {
    }

	public partial interface IFW_GEO_NODE_REPOSITORY: IBaseDALRepository<MODEL.FW_GEO_NODE>
    {
    }

	public partial interface IFW_GEO_NODE_CUST_REPOSITORY: IBaseDALRepository<MODEL.FW_GEO_NODE_CUST>
    {
    }

	public partial interface IFW_GEO_TREE_REPOSITORY: IBaseDALRepository<MODEL.FW_GEO_TREE>
    {
    }

	public partial interface IFW_GEO_TREE_LEVEL_REPOSITORY: IBaseDALRepository<MODEL.FW_GEO_TREE_LEVEL>
    {
    }

	public partial interface IFW_MODULE_REPOSITORY: IBaseDALRepository<MODEL.FW_MODULE>
    {
    }

	public partial interface IFW_MODULEPERMISSION_REPOSITORY: IBaseDALRepository<MODEL.FW_MODULEPERMISSION>
    {
    }

	public partial interface IFW_OPERATELOG_REPOSITORY: IBaseDALRepository<MODEL.FW_OPERATELOG>
    {
    }

	public partial interface IFW_PERMISSION_REPOSITORY: IBaseDALRepository<MODEL.FW_PERMISSION>
    {
    }

	public partial interface IFW_ROLE_REPOSITORY: IBaseDALRepository<MODEL.FW_ROLE>
    {
    }

	public partial interface IFW_ROLEPERMISSION_REPOSITORY: IBaseDALRepository<MODEL.FW_ROLEPERMISSION>
    {
    }

	public partial interface IFW_USER_REPOSITORY: IBaseDALRepository<MODEL.FW_USER>
    {
    }

	public partial interface IFW_USER_ASSIGN_REPOSITORY: IBaseDALRepository<MODEL.FW_USER_ASSIGN>
    {
    }

	public partial interface IFW_USER_ROLE_REPOSITORY: IBaseDALRepository<MODEL.FW_USER_ROLE>
    {
    }

	public partial interface IJF_Order_REPOSITORY: IBaseDALRepository<MODEL.JF_Order>
    {
    }

	public partial interface IJF_Product_REPOSITORY: IBaseDALRepository<MODEL.JF_Product>
    {
    }

	public partial interface IMST_ARTICLE_REPOSITORY: IBaseDALRepository<MODEL.MST_ARTICLE>
    {
    }

	public partial interface IMST_ATTACHMENTS_REPOSITORY: IBaseDALRepository<MODEL.MST_ATTACHMENTS>
    {
    }

	public partial interface IMST_CAR_REPOSITORY: IBaseDALRepository<MODEL.MST_CAR>
    {
    }

	public partial interface IMST_CATALOG_REPOSITORY: IBaseDALRepository<MODEL.MST_CATALOG>
    {
    }

	public partial interface IMST_CATEGORY_REPOSITORY: IBaseDALRepository<MODEL.MST_CATEGORY>
    {
    }

	public partial interface IMST_COMPANY_REPOSITORY: IBaseDALRepository<MODEL.MST_COMPANY>
    {
    }

	public partial interface IMST_COMPANY_MEM_REPOSITORY: IBaseDALRepository<MODEL.MST_COMPANY_MEM>
    {
    }

	public partial interface IMST_MEMBER_REPOSITORY: IBaseDALRepository<MODEL.MST_MEMBER>
    {
    }

	public partial interface IMST_MUSTSELL_REPOSITORY: IBaseDALRepository<MODEL.MST_MUSTSELL>
    {
    }

	public partial interface IMST_MUSTSELL_DTL_REPOSITORY: IBaseDALRepository<MODEL.MST_MUSTSELL_DTL>
    {
    }

	public partial interface IMST_MUSTSELL_PRD_REPOSITORY: IBaseDALRepository<MODEL.MST_MUSTSELL_PRD>
    {
    }

	public partial interface IMST_POSITION_REPOSITORY: IBaseDALRepository<MODEL.MST_POSITION>
    {
    }

	public partial interface IMST_PRD_REPOSITORY: IBaseDALRepository<MODEL.MST_PRD>
    {
    }

	public partial interface IMST_PRD_CATE_REPOSITORY: IBaseDALRepository<MODEL.MST_PRD_CATE>
    {
    }

	public partial interface IMST_PRD_IMG_REPOSITORY: IBaseDALRepository<MODEL.MST_PRD_IMG>
    {
    }

	public partial interface IMST_RESUME_REPOSITORY: IBaseDALRepository<MODEL.MST_RESUME>
    {
    }

	public partial interface IMST_RESUME_DTL_REPOSITORY: IBaseDALRepository<MODEL.MST_RESUME_DTL>
    {
    }

	public partial interface IMST_SUPPLIER_REPOSITORY: IBaseDALRepository<MODEL.MST_SUPPLIER>
    {
    }

	public partial interface ISET_COUNTRY_REPOSITORY: IBaseDALRepository<MODEL.SET_COUNTRY>
    {
    }

	public partial interface ISET_NAVIGATION_ITEM_REPOSITORY: IBaseDALRepository<MODEL.SET_NAVIGATION_ITEM>
    {
    }

	public partial interface ISET_REGION_REPOSITORY: IBaseDALRepository<MODEL.SET_REGION>
    {
    }

	public partial interface ISYS_REF_REPOSITORY: IBaseDALRepository<MODEL.SYS_REF>
    {
    }

	public partial interface ISYS_USERLOGIN_REPOSITORY: IBaseDALRepository<MODEL.SYS_USERLOGIN>
    {
    }

	public partial interface ITG_Address_REPOSITORY: IBaseDALRepository<MODEL.TG_Address>
    {
    }

	public partial interface ITG_BankCrad_REPOSITORY: IBaseDALRepository<MODEL.TG_BankCrad>
    {
    }

	public partial interface ITG_Car_REPOSITORY: IBaseDALRepository<MODEL.TG_Car>
    {
    }

	public partial interface ITG_fenxiaoConfig_REPOSITORY: IBaseDALRepository<MODEL.TG_fenxiaoConfig>
    {
    }

	public partial interface ITG_jifenLog_REPOSITORY: IBaseDALRepository<MODEL.TG_jifenLog>
    {
    }

	public partial interface ITG_order_REPOSITORY: IBaseDALRepository<MODEL.TG_order>
    {
    }

	public partial interface ITG_pic_REPOSITORY: IBaseDALRepository<MODEL.TG_pic>
    {
    }

	public partial interface ITG_product_REPOSITORY: IBaseDALRepository<MODEL.TG_product>
    {
    }

	public partial interface ITG_productBrand_REPOSITORY: IBaseDALRepository<MODEL.TG_productBrand>
    {
    }

	public partial interface ITG_productCate_REPOSITORY: IBaseDALRepository<MODEL.TG_productCate>
    {
    }

	public partial interface ITG_productColor_REPOSITORY: IBaseDALRepository<MODEL.TG_productColor>
    {
    }

	public partial interface ITG_QD_REPOSITORY: IBaseDALRepository<MODEL.TG_QD>
    {
    }

	public partial interface ITG_redPaperLog_REPOSITORY: IBaseDALRepository<MODEL.TG_redPaperLog>
    {
    }

	public partial interface ITG_review_REPOSITORY: IBaseDALRepository<MODEL.TG_review>
    {
    }

	public partial interface ITG_SCproduct_REPOSITORY: IBaseDALRepository<MODEL.TG_SCproduct>
    {
    }

	public partial interface ITG_Thing_REPOSITORY: IBaseDALRepository<MODEL.TG_Thing>
    {
    }

	public partial interface ITG_transactionLog_REPOSITORY: IBaseDALRepository<MODEL.TG_transactionLog>
    {
    }

	public partial interface ITG_tuihuo_REPOSITORY: IBaseDALRepository<MODEL.TG_tuihuo>
    {
    }

	public partial interface ITG_TXmoney_REPOSITORY: IBaseDALRepository<MODEL.TG_TXmoney>
    {
    }

	public partial interface ITG_wuliu_REPOSITORY: IBaseDALRepository<MODEL.TG_wuliu>
    {
    }

	public partial interface ITokenConfig_REPOSITORY: IBaseDALRepository<MODEL.TokenConfig>
    {
    }

	public partial interface IYX_Event_REPOSITORY: IBaseDALRepository<MODEL.YX_Event>
    {
    }

	public partial interface IYX_image_REPOSITORY: IBaseDALRepository<MODEL.YX_image>
    {
    }

	public partial interface IYX_music_REPOSITORY: IBaseDALRepository<MODEL.YX_music>
    {
    }

	public partial interface IYX_news_REPOSITORY: IBaseDALRepository<MODEL.YX_news>
    {
    }

	public partial interface IYX_sysConfigs_REPOSITORY: IBaseDALRepository<MODEL.YX_sysConfigs>
    {
    }

	public partial interface IYX_sysLog_REPOSITORY: IBaseDALRepository<MODEL.YX_sysLog>
    {
    }

	public partial interface IYX_sysNews_REPOSITORY: IBaseDALRepository<MODEL.YX_sysNews>
    {
    }

	public partial interface IYX_text_REPOSITORY: IBaseDALRepository<MODEL.YX_text>
    {
    }

	public partial interface IYX_video_REPOSITORY: IBaseDALRepository<MODEL.YX_video>
    {
    }

	public partial interface IYX_voice_REPOSITORY: IBaseDALRepository<MODEL.YX_voice>
    {
    }

	public partial interface IYX_weiUser_REPOSITORY: IBaseDALRepository<MODEL.YX_weiUser>
    {
    }

	public partial interface IYX_weiXinMenus_REPOSITORY: IBaseDALRepository<MODEL.YX_weiXinMenus>
    {
    }


}