using System;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using Inventor;

namespace ChangeParamAddIn
{
    /// <summary>
    /// ChangeParamButton class
    /// </summary>
    internal class ChangeParamUI
    {
        private ChangeParamButton m_ChangeParamButton;

        //user interface event
        private UserInterfaceEvents m_userInterfaceEvents;

        Inventor.Application m_inventorApplication;

        public ChangeParamUI()
        {

        }

        public void InitUI(AddInServer addIn, bool firstTime, Inventor.Application inventorApplication)
        {
            m_inventorApplication = inventorApplication;
            Button.InventorApplication = m_inventorApplication;

            //load image icons for UI items
            Icon ChangeParamIcon = new Icon(this.GetType(), "ChangeParam.ico");

            //retrieve the GUID for this class
            GuidAttribute addInCLSID;
            addInCLSID = (GuidAttribute)GuidAttribute.GetCustomAttribute(typeof(AddInServer), typeof(GuidAttribute));
            string addInCLSIDString;
            addInCLSIDString = "{" + addInCLSID.Value + "}";

            m_ChangeParamButton = new ChangeParamButton(addIn,
                "ChangeParam", "Autodesk:ChangeParamAddIn:ChangeParamCmdBtn", CommandTypesEnum.kShapeEditCmdType,
                addInCLSIDString, "Changes a part param",
                "ChangeParam", ChangeParamIcon, ChangeParamIcon, ButtonDisplayEnum.kDisplayTextInLearningMode);

            if (firstTime == true)
            {
                //access user interface manager
                UserInterfaceManager userInterfaceManager;
                userInterfaceManager = m_inventorApplication.UserInterfaceManager;

                InterfaceStyleEnum interfaceStyle;
                interfaceStyle = userInterfaceManager.InterfaceStyle;


                //get the ribbon associated with part document
                Inventor.Ribbons ribbons;
                ribbons = userInterfaceManager.Ribbons;

                Inventor.Ribbon partRibbon;
                partRibbon = ribbons["Part"];

                //get the tabs associated with part ribbon
                RibbonTabs ribbonTabs;
                ribbonTabs = partRibbon.RibbonTabs;

                RibbonTab partViewRibbonTab;
                partViewRibbonTab = ribbonTabs["id_TabModel"];

                //create a new panel with the tab
                RibbonPanels ribbonPanels;
                ribbonPanels = partViewRibbonTab.RibbonPanels;

                RibbonPanel appearancePanel = ribbonPanels["id_PanelP_ModelModify"];

                CommandControls panelCtrls = appearancePanel.CommandControls;
                CommandControl ChangeParamCmdBtnCmdCtrl;
                ChangeParamCmdBtnCmdCtrl = panelCtrls.AddButton(m_ChangeParamButton.ButtonDefinition, false, true, "", false);

            }
        }
    }

    internal class ChangeParamButton : Button
    {
        AddInServer m_addInServer;
      

        #region "Methods"

        public ChangeParamButton(AddInServer addInServer, string displayName, string internalName, CommandTypesEnum commandType, string clientId, string description, string tooltip, Icon standardIcon, Icon largeIcon, ButtonDisplayEnum buttonDisplayType)
            : base(displayName, internalName, commandType, clientId, description, tooltip, standardIcon, largeIcon, buttonDisplayType)
        {
            m_addInServer = addInServer;
        }

        public ChangeParamButton(AddInServer addInServer, string displayName, string internalName, CommandTypesEnum commandType, string clientId, string description, string tooltip, ButtonDisplayEnum buttonDisplayType)
            : base(displayName, internalName, commandType, clientId, description, tooltip, buttonDisplayType)
        {
            m_addInServer = addInServer;
        }

        override protected void ButtonDefinition_OnExecute(NameValueMap context)
        {
            try
            {
                m_addInServer.ChangeParam();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        #endregion

      
    }
}
