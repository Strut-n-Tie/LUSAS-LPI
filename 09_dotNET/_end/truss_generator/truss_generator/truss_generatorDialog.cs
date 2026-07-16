//*******************************************************************
// truss_generatorDialog.cs
// (c) Copyright 2026, Finite Element Analysis Ltd., Kingston
//
// truss_generatorDialog class implementation file
//*******************************************************************

using Lusas.LPI;
using Lusas.Module;
using Lusas.Utils.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using truss_generator.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace truss_generator
{
    /// <summary>
    /// Module dialog providing UI to access truss_generatorModule functionality
    /// </summary>
    public partial class truss_generatorDialog : LusasModuleDialog
    {
        #region Private members
        private truss_generatorModule m_module; // Reference to the module 
        private IFModeller m_modeller; // Reference to Modeller
        private int textOutError_E = 6;
        private int textOutInfo_E = 6;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructs an instance of the safeprojectnameModule dialog
        /// </summary>
        /// <param name="lusasModule"></param>
        public truss_generatorDialog(truss_generatorModule lusasModule) : base(lusasModule)
        {
            m_module = lusasModule;
            m_modeller = lusasModule.Modeller;

            InitializeComponent();

            pictureBox1.Image = Resources.truss_image;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            load_combobox_material_attributes();
            load_combobox_mesh_attributes();
            load_combobox_mesh_attributes();
            load_combobox_geometric_attributes_top_chord();
            load_combobox_geometric_attributes_bottom_chord();
            load_combobox_geometric_attributes_diagional();
        }
        #endregion

        #region Private functions
        /// <summary>
        /// Read existing material attributes from the modeller and populate the combo box.
        /// </summary>
        private void load_combobox_material_attributes()
        {
            comboBox_material_attr.Items.Clear();
            IFAttribute[] attrSet = CastObject<IFAttribute>.arrayFromArrayObject(m_modeller.database().getAttributes("Material"));

            for (int i = 0; i < attrSet.Length; i++)
            {
                IFAttribute attr = attrSet[i];
                comboBox_material_attr.Items.Add(attr.getName());
            }
            if (attrSet.Length > 0) { comboBox_material_attr.SelectedIndex = 0; }
            comboBox_material_attr.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Read existing mesh attributes from the modeller and populate the combo box.
        /// </summary>
        private void load_combobox_mesh_attributes()
        {
            comboBox_mesh_attr.Items.Clear();
            IFAttribute[] attrSet = CastObject<IFAttribute>.arrayFromArrayObject(m_modeller.database().getAttributes("Mesh"));

            for (int i = 0; i < attrSet.Length; i++)
            {
                IFAttribute attr = attrSet[i];
                comboBox_mesh_attr.Items.Add(attr.getName());
            }
            if (attrSet.Length > 0) { comboBox_mesh_attr.SelectedIndex = 0; }
            comboBox_mesh_attr.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Read existing geometric attributes from the modeller and populate the combo box.
        /// </summary>
        private void load_combobox_geometric_attributes_top_chord()
        {
            comboBox_section_top_chord.Items.Clear();
            IFAttribute[] attrSet = CastObject<IFAttribute>.arrayFromArrayObject(m_modeller.database().getAttributes("Geometric"));

            for (int i = 0; i < attrSet.Length; i++)
            {
                IFAttribute attr = attrSet[i];
                comboBox_section_top_chord.Items.Add(attr.getName());
            }
            if (attrSet.Length > 0) { comboBox_section_top_chord.SelectedIndex = 0; }
            comboBox_section_top_chord.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Read existing geometric attributes from the modeller and populate the combo box.
        /// </summary>
        private void load_combobox_geometric_attributes_bottom_chord()
        {
            comboBox_section_bottom_chord.Items.Clear();
            IFAttribute[] attrSet = CastObject<IFAttribute>.arrayFromArrayObject(m_modeller.database().getAttributes("Geometric"));

            for (int i = 0; i < attrSet.Length; i++)
            {
                IFAttribute attr = attrSet[i];
                comboBox_section_bottom_chord.Items.Add(attr.getName());
            }
            if (attrSet.Length > 0) { comboBox_section_bottom_chord.SelectedIndex = 0; }
            comboBox_section_bottom_chord.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Read existing geometric attributes from the modeller and populate the combo box.
        /// </summary>
        private void load_combobox_geometric_attributes_diagional()
        {
            comboBox_section_diagonal.Items.Clear();
            IFAttribute[] attrSet = CastObject<IFAttribute>.arrayFromArrayObject(m_modeller.database().getAttributes("Geometric"));

            for (int i = 0; i < attrSet.Length; i++)
            {
                IFAttribute attr = attrSet[i];
                comboBox_section_diagonal.Items.Add(attr.getName());
            }
            if (attrSet.Length > 0) { comboBox_section_diagonal.SelectedIndex = 0; }
            comboBox_section_diagonal.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Read dialog entries.
        /// </summary>
        /// <returns>DataContainer with dialog entries</returns>
        private DataContainer readDialog()
        {
            try
            {
                DataContainer data_container = new DataContainer();
                // Material attribute
                if (comboBox_material_attr.Items.Count > 0)
                {
                    data_container.material_attribute_name = comboBox_material_attr.SelectedItem.ToString();
                }
                else
                {
                    throw new Exception("Wrong material attribute");
                }
                // Mesh attribute
                if (comboBox_mesh_attr.Items.Count > 0)
                {
                    data_container.mesh_attribte_name = comboBox_mesh_attr.SelectedItem.ToString();
                }
                else
                {
                    throw new Exception("Wrong mesh attribute");
                }
                // Geometric attribute top chord
                if (comboBox_section_top_chord.Items.Count > 0)
                {
                    data_container.geometric_attribte_top_chord_name = comboBox_section_top_chord.SelectedItem.ToString();
                }
                else
                {
                    throw new Exception("Wrong geometric attribute top chord");
                }
                // Geometric attribute bottom chord
                if (comboBox_section_bottom_chord.Items.Count > 0)
                {
                    data_container.geometric_attribte_bottom_chord_name = comboBox_section_bottom_chord.SelectedItem.ToString();
                }
                else
                {
                    throw new Exception("Wrong geometric attribute bottom chord");
                }
                // Geometric attribute diagonal
                if (comboBox_section_diagonal.Items.Count > 0)
                {
                    data_container.geometric_attribte_diagonal_name = comboBox_section_diagonal.SelectedItem.ToString();
                }
                else
                {
                    throw new Exception("Wrong geometric attribute diagonal");
                }
                // Height
                string stringParser = textBox_H.Text;
                bool success = double.TryParse(stringParser, out double result);
                if (success && result > 0)
                {
                    data_container.H = result;
                }
                else
                {
                    throw new Exception("Height must be a positive number");
                }
                // Length
                stringParser = textBox_L.Text;
                success = double.TryParse(stringParser, out result);
                if (success && result > 0)
                {
                    data_container.L = result;
                }
                else
                {
                    throw new Exception("Length must be a positive number");
                }
                // Number of spans
                stringParser = textBox_n.Text;
                success = int.TryParse(stringParser, out int resultInt);
                if (success && result > 0)
                {
                    data_container.n = resultInt;
                }
                else
                {
                    throw new Exception("Number of spans must be a positive integer");
                }
                return data_container;
            }
            catch (Exception exception)
            {
                m_modeller.AfxMsgBox(exception.Message, textOutError_E);
                return null;
            }
        }
        #endregion

        #region Event handlers
        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            Processor processor = new Processor(m_modeller);
            DataContainer dialog_data = readDialog();
            if (dialog_data != null)
            {
                Close();
            }
        }
        #endregion
    }
}
