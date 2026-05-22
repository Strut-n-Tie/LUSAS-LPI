//*******************************************************************
// truss_generatorModule.cs
// (c) Copyright 2026, Finite Element Analysis Ltd., Kingston
//
// truss_generatorModule class implementation file
//*******************************************************************

using Lusas.LPI;
using Lusas.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace truss_generator
{
    /// <summary>
    /// COM Interface exposing module functionality
    /// </summary>
    [ComVisible(true)]
    [Guid("9f95ccf6-61d5-4cb3-886f-f5ad82bbaac6"), InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface Itruss_generatorModule
    {
    }


    /// <summary>
    /// The main truss_generator module class that interoperates with Modeller.
    /// </summary>
    [ComVisible(true)]
    [Guid("acdd91ee-046e-43ae-9bc2-7b9d6c0de3ca"), ClassInterface(ClassInterfaceType.None)]
    public class truss_generatorModule : LusasModuleClass, Itruss_generatorModule
    {
        #region Menu Event Handlers

        private long m_menuID;      // Temporary menu item ID 

        /// <summary>
        /// Called when Modeller is redrawing the Main Menu.
        /// </summary>
        /// <remarks>
        /// Perform temporary dev-only customisation to Modeller's main menu here.
        /// Note - modules intended for release should NOT use this method to add themselves into
        /// modeller's menu - instead the menu item should be properly and consistently added into
        /// LUSASres.rc and the class should override onMenuUpdate() and onMenuClick()
        /// </remarks>
        protected override void onRefreshMainMenu()
        {
            // Create a default [Modules] > [Module Name] menu for development.
            IFMenu rootMenu = Modeller.getMainMenu();
            IFMenu modMenu;
            if (rootMenu.exists("Modules"))
            {
                modMenu = rootMenu.getSubMenu("Modules");
            }
            else
            {
                modMenu = rootMenu.appendMenu("Modules");
            }
            m_menuID = modMenu.appendItem("truss_generator", @"Display ""Truss Generator"" Dialog");
        }


        /// <summary>
        /// Called when the user clicks on a menu entry.
        /// </summary>
        /// <param name="menuID">ID of the menu that has been clicked.</param>
        /// <param name="edittingObj">Object that is being edited (nothing when creating a new object).</param>
        /// <param name="clientData">Data that was provided to Modeller when defining edittingObj.</param>
        /// <returns>true if the click event was handled by this Module.</returns>
        /// <remarks>
        /// LUSAS expects the a Module handling the event to execute itself (typically using runModule()).
        /// </remarks>
        protected override bool onMenuClick(int menuID, object edittingObj, object clientData = null)
        {
            if (m_menuID == menuID)
            {
                using (var dlg = new truss_generatorDialog(this))
                {
                    dlg.ShowDialog();
                }
                return true; // Handled the menu event
            }
            return false; // Allow others to handle the event
        }


        /// <summary>
        /// Called when a menu entry needs to be drawn.
        /// Allows the Module to specify whether the menu item should be disabled or checked.
        /// </summary>
        /// <param name="menuID">ID of the menu that has been clicked.</param>
        /// <param name="edittingObj">Object that is being edited (nothing when creating a new object).</param>
        /// <param name="enable">Set to true to enable the menu item.</param>
        /// <param name="isChecked">
        /// Set to 0 to show an 'off' tickbox next to the menu.
        /// Set to 1 to show an 'on' tick mark by the side of the menu.
        /// Set to 2 to show an indeterminate check.
        /// Set to 3 to show no tick at all.
        /// </param>
        /// <param name="clientData">Data that was provided to Modeller when defining edittingObj.</param>
        /// <returns>true if the update event was handled by this Module.</returns>
        /// <remarks>
        /// Only when a Module handles an menu update event are the changed values of enable/checked respected.
        /// </remarks>
        protected override bool onMenuUpdate(int menuID, object edittingObj, ref bool enable, ref int isChecked, object clientData = null)
        {
            if (m_menuID == menuID)
            {
                enable = true;
                return true; // Handled the menu event
            }
            return false; // Allow others to handle the event
        }


        #endregion
    }

}
