using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.IO.Compression;
using System.Globalization;

namespace XMLFileAdministrator
{
    public partial class Inicio : Form
    {
        readonly string RootPath = Application.StartupPath; //Variable que indica la ruta raíz del ejecutable
        readonly string tempUnzip = Application.StartupPath + @"\\backup\\temp\\unzipped\\"; //Variable que indica la ruta de los archivos temporales
        readonly string home = "https://portalcfdi.facturaelectronica.sat.gob.mx/"; //Variable de inicio del browser
        Point columnClicked = new Point(0, 0); //Variable que indica la localización del puntero al hacer click derecho en una columna
        bool Preferencias = false; //Variable que indica si existe el archivo de preferencias/columnas
        bool Default = false; //Variable que indica si existe el archivo de default/columnas
        TimbreFiscalDigital auxTimbre = new TimbreFiscalDigital();

        //  *** INICIALIZADORES O CONSTRUCTORES *** \\
        public Inicio()
        {
            InitializeComponent();
            LoadSettings();
            InitializeColumns();
            InitializeWebBrowser();
            //Añade el evento click derecho a los headers del grid
            XMLDataGridView.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(XMLDG_ColumnHeaderMouseClick);
            //Colorea las cabeceras de las columnas, el azul se ve bonito
            XMLDataGridView.EnableHeadersVisualStyles = false;
            XMLDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void LoadSettings() //Carga el archivo de configuraciones
        {
            if (File.Exists(RootPath + @"\\backup\\settings\\preferences\\columns.txt")) //Si existe el archivo de preferencias
            {
                Preferencias = true;
            }
            else if (File.Exists(RootPath + @"\\backup\\settings\\default\\columns.txt")) //Si no
            {
                /* MessageBox.Show("Faltan archivos de preferencias.\nEs probable que estén dañados o hayan sido eliminados.\nEn su lugar, se mostrará la configuración por defecto.",
                                     "Info",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);*/
                Default = true;
            }
            else //Si no existe ninguna de ellas, muestra mensaje y no carga archivos de configuración
            {
                MessageBox.Show("No se encontró ningún archivo con la configuración deseada.\nSe anexarán las columnas dependiendo del archivo que cargue.\nEl programa podría no funcionar adecuadamente, " +
                                "para más información, leer el apartado 'Ayuda' en el sistema",
                                    "Info",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }
        }

        private void InitializeColumns() //Función que Inicializa las columnas, según la preferencia del usuario
        {
            string rutaSettings = string.Empty;
            if (Preferencias)
                rutaSettings += RootPath + @"\\backup\\settings\\preferences\\columns.txt";
            else if(Default)
                rutaSettings += RootPath + @"\\backup\\settings\\default\\columns.txt";
            if (!string.IsNullOrWhiteSpace(rutaSettings))
            {
                string contentOfFile = File.ReadAllText(rutaSettings); //Es el contenido del archivo
                foreach (string c in contentOfFile.Split('\n')) //Para cada columna
                {
                    if (!string.IsNullOrWhiteSpace(c)) //Que no sea nula, espacio o vacía
                    {
                        string colName = c.Split('|')[0]; //Asignamos el nombre en una variable
                        bool active = (c.Split('|')[1][0] != '0'); //Asignamos si será visible o no
                        string tipoDato = c.Split('|')[2].Trim(); //Asignamos el tipo de dato de la columna
                        ColumnasCheckedListBox.Items.Add(colName, active); //Insertamos la columna a la checkedList
                        XMLDataGridView.Columns.Add(colName, colName); //Insertamos la columna en el grid
                        XMLDataGridView.Columns[XMLDataGridView.ColumnCount - 1].Visible = active; //Determinamos su visibilidad
                        if (tipoDato == "decimal") //Si el tipo de dato es un decimal
                            XMLDataGridView.Columns[XMLDataGridView.ColumnCount - 1].ValueType = typeof(Decimal);
                        else
                            XMLDataGridView.Columns[XMLDataGridView.ColumnCount - 1].ValueType = typeof(string);
                        if (XMLDataGridView.Columns[XMLDataGridView.ColumnCount - 1].Width > 150) //Ajusta el ancho de una columna
                        {
                            XMLDataGridView.Columns[XMLDataGridView.ColumnCount - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                            XMLDataGridView.Columns[XMLDataGridView.ColumnCount - 1].Width = 150;
                        }
                    }
                }
                EditGroupBox.Text = "Editar columnas (" + ColumnasCheckedListBox.Items.Count + ")"; //Mostramos el contador de columnas
            }
        }

        private void InitializeWebBrowser()
        {
            SatWebBrowser.ScriptErrorsSuppressed = true;
            SatWebBrowser.Navigate(home);
            SatWebBrowser.NewWindow += SatWebBrowser_NewWindow;
        }

        private void SatWebBrowser_NewWindow(object sender, CancelEventArgs e) //Evita que abra el navegador en una pestaña externa
        {
            var url = SatWebBrowser.Document.ActiveElement.GetAttribute("href"); //Establece el enlace destino
            if (string.IsNullOrWhiteSpace(url))
                SatWebBrowser.Navigate(url); //Carga ese enlace en el mismo Web Browser
            e.Cancel = true; //Cancela el inicio del navegador
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            SatWebBrowser.Navigate(home);
        }

        //  *** EVENTOS *** \\\
        void XMLDG_ColumnHeaderMouseClick(object sender, MouseEventArgs e) //Muestra un menú secundario
        {
            if (e.Button == MouseButtons.Right) //Al hacer click derecho
            {
                ContextMenuStrip menu = new ContextMenuStrip(); //Menú secundario
                menu.Items.Add("Ocultar columna").Name = "Del"; //Opciones del menú secundario
                //Guarda la localización del puntero con respecto al programa 8, 30 es el tamaño del cursor
                columnClicked.X = Cursor.Position.X - this.Location.X - 8;
                columnClicked.Y = Cursor.Position.Y - this.Location.Y - 30;
                int mouseOverColumn = XMLDataGridView.HitTest(columnClicked.X, columnClicked.Y).ColumnIndex - 2; //Índice de la columna que recibió el click
                //MessageBox.Show(XMLDataGridView.HitTest(columnClicked.X, columnClicked.Y).ToString()); //Pequeño Log-debug
                if (mouseOverColumn > 0)//Si existe la columna
                {
                    menu.Show(this, columnClicked); //Muestra el menú secundario
                    menu.ItemClicked += Menu_ItemClicked; //Evento que se ejecuta al hacer click en un elemento del menú secundario
                }
            }
        }

        private void Menu_ItemClicked(object sender, ToolStripItemClickedEventArgs e) //Obtiene la opción del menú secundario al que se accedió
        {
            // TODO: Arreglar bug de click derecho en columnas
            switch (e.ClickedItem.Name) //Dependiendo el elemento al que se hizo click
            {
                case "Del":
                    int mouseOverColumn = XMLDataGridView.HitTest(columnClicked.X, columnClicked.Y).ColumnIndex - 2; //Ïndice de la columna
                    string colToDel = XMLDataGridView.Columns[mouseOverColumn].HeaderText; //Nombre de la columna a eliminar
                    int index = ColumnasCheckedListBox.Items.IndexOf(colToDel); //Índice de la columna
                    ColumnasCheckedListBox.SetItemChecked(index, false); //Desactivar del checkedList
                    //MessageBox.Show(columnClicked.X.ToString() + " " + columnClicked.Y.ToString() + "\n" + Cursor.Position.X + " " + Cursor.Position.Y); //Log-debug
                    XMLDataGridView.Columns[mouseOverColumn].Visible = false; //Oculta columna del grid
                    break;
            }
        }

        private void TypeOfFileComboBox_SelectedIndexChanged(object sender, EventArgs e) //Limpia el Span de la ruta
        {
            RutaSpan.Text = string.Empty;
        }

        private void OpenFileButton_Click(object sender, EventArgs e) //Al hacer click en 'Examinar'
        {
            var filePath = string.Empty;
            if (TypeOfFileComboBox.Text == "Por carpeta") //Si el tipo de archivo a cargar es una carpeta
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog(); //Abre diálogo de carpeta
                fbd.Description = "Selecciona la carpeta con los archivos a cargar...";
                fbd.ShowNewFolderButton = false;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    filePath = fbd.SelectedPath; //Asigna la ruta elegida a nuestra variable
                }
            }
            else //Si es un archivo individual
            {
                OpenFileDialog ofd = new OpenFileDialog();
                //ofd.InitialDirectory = "c:\\"; 
                //ofd.RestoreDirectory = true;
                ofd.Filter = "Archivos XML|*.xml|Todos los archivos (*.*)|*.*";
                ofd.FilterIndex = 2;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName; //Asigna la ruta a nuestra variable
                }
            }
            if (filePath != string.Empty) //Si eligió una ruta válida
            {
                RutaSpan.Text = filePath; //Muestra la ruta
                AddButton.Enabled = true; //Habilita el botón para añadir los datos al grid
            }
        }

        private void AddButton_Click(object sender, EventArgs e) //Al hacer click en 'Añadir'
        {
            if (!string.IsNullOrEmpty(RutaSpan.Text)) //Si la ruta es válida
            {
                LoadDataProgressBar.Visible = true;
                try
                {
                    if (TypeOfFileComboBox.Text == "Por carpeta") //Si se carga una carpeta
                    {
                        string[] archivos = Directory.GetFiles(RutaSpan.Text); //Separa todos los archivos en la carpeta
                        int countResultados = 0;
                        LoadDataProgressBar.Maximum = archivos.Length + 1;
                        LoadDataProgressBar.Value = 1;
                        //decimal step = 100 / archivos.Length;
                        LoadDataProgressBar.Step = 1;
                        foreach (string arch in archivos) //Para cada archivo
                        {
                            if (Path.GetExtension(arch) == ".xml") //Si se trata de un archivo XML, léelo y aumenta el contador
                            {
                                ReadFile(arch);
                                countResultados++;
                            }
                            LoadDataProgressBar.PerformStep();
                        }
                        if (countResultados == 0) //Si no encontró archivos
                            throw new System.Exception("No existen archivos XML en la carpeta seleccionada.");
                    }
                    else if (TypeOfFileComboBox.Text == "Carpeta comprimida (zip)")
                    {
                        string directoryName = RutaSpan.Text.Split('\\')[RutaSpan.Text.Split('\\').Length - 1].Replace(".zip", string.Empty);
                        ZipFile.ExtractToDirectory(RutaSpan.Text, tempUnzip); //Extrae la carpeta que el usuario eligió en una carpeta temporal
                        string[] archivos;
                        if (Directory.Exists(tempUnzip + @"\\" + directoryName)) //Si se extrajo una carpeta
                        {
                            archivos = Directory.GetFiles(tempUnzip + @"\\" + directoryName); //Carga los archivos de esa carpeta
                        }
                        else //Si se extrajeron archivos
                        {
                            archivos = Directory.GetFiles(tempUnzip); //Carga los archivos extraídos
                        }
                        LoadDataProgressBar.Maximum = archivos.Length + 1; 
                        LoadDataProgressBar.Value = 1;
                        LoadDataProgressBar.Step = 1;
                        int countResultados = 0;
                        foreach (string arch in archivos)
                        {
                            if (Path.GetExtension(arch) == ".xml") //Si el archivo es un xml
                            {
                                ReadFile(arch);
                                countResultados++;
                            }
                            LoadDataProgressBar.PerformStep();
                        }
                        if (Directory.Exists(tempUnzip)) //Si existe la carpeta unzipped, elimina todo lo que contiene
                        {
                            DirectoryInfo dirZip = new DirectoryInfo(tempUnzip);
                            foreach (FileInfo file in dirZip.EnumerateFiles())
                                file.Delete();
                            foreach (DirectoryInfo dir in dirZip.EnumerateDirectories())
                                dir.Delete(true);
                        }

                        if (countResultados == 0) //Si no encontró archivos
                            throw new System.Exception("No existen archivos XML en la carpeta seleccionada.");
                    }
                    else //Si se carga un archivo individual
                    {
                        LoadDataProgressBar.Maximum = 2;
                        LoadDataProgressBar.Value = 1;
                        if (Path.GetExtension(RutaSpan.Text) != ".xml") //Si NO es un XML
                            throw new System.Exception("El archivo elegido debe ser un XML.");
                        ReadFile(RutaSpan.Text); //En caso contrario, léelo
                        LoadDataProgressBar.Value = 2;
                    }
                }
                catch (Exception excp)
                {
                    MessageBox.Show("Ocurrió un error imprevisto. Detalles: " + excp.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //FillGridEmptySpaces();
            }
            else //Por si la ruta no ha sido seleccionada
            {
                MessageBox.Show("Elige un archivo o una carpeta para continuar...", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            AddButton.Enabled = false;
            LoadDataProgressBar.Visible = false;
        }

        private void ColumnasCheckedListBox_SelectedIndexChanged(object sender, EventArgs e) //Cada vez que se dé click en un check
        {
            string colName = ColumnasCheckedListBox.Items[ColumnasCheckedListBox.SelectedIndex].ToString(); //Obtiene el nombre de la columna
            //La oculta si es visible o la muestra si no lo es
            if (XMLDataGridView.Columns[colName].Visible)
                XMLDataGridView.Columns[colName].Visible = false;
            else
                XMLDataGridView.Columns[colName].Visible = true;
        }

        private void CleanButton_Click(object sender, EventArgs e) //Para limpiar el grid
        {
            if(MessageBox.Show("¿Está seguro que desea eliminar todos los registros mostrados en la tabla?\nEsta acción no se puede deshacer",
                                "Atención", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                XMLDataGridView.Rows.Clear(); //Limpia las filas del grid
                RutaSpan.Clear(); //Limpia la ruta
                if (!Preferencias && !Default) //Si el archivo de preferencias no existe o no se encontró
                {
                    XMLDataGridView.Columns.Clear(); //Limpia las columnas
                    ColumnasCheckedListBox.Items.Clear();
                    EditGroupBox.Text = "Editar columnas"; //Reinicia el box
                    XMLDataGridView.Columns.Add("_ID", "No. archivo");
                    XMLDataGridView.Columns[0].Visible = false;
                }
            }
        }

        private void FileExtensionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExportButton.Enabled = true;
        }

        private void ExportButton_Click(object sender, EventArgs e)
        {
            ExportProgressBar.Visible = true;
            if (XMLDataGridView.RowCount > 0) //Revisa si existen datos qué exportar
            {
                ExportProgressBar.Maximum = XMLDataGridView.RowCount;
                ExportProgressBar.Value = 1;
                ExportProgressBar.Step = 1;
                switch (FileExtensionComboBox.Text)
                {
                    case "Csv":
                        ExportGridToCSV();
                        break;
                    case "Texto":
                        MessageBox.Show("De momento, esta opción no está disponible.");
                        break;
                    case "Excel":
                        ExportGridFast();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Debes cargar archivos al programa antes de exportarlos.",
                                "Info",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                ExportButton.Enabled = false;
                FileExtensionComboBox.Text = string.Empty;
            }
            ExportProgressBar.Visible = false;
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e) //Código que se ejecuta al cerrar el programa
        {
            if (MessageBox.Show("¿Desea guardar sus cambios en las preferencias?\nLa próxima vez, se recordarán sus columnas seleccionadas.",
                                "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string settings = RootPath + @"\\backup\\settings\\default\\columns.txt";
                string newPreferences = RootPath + @"\\backup\\settings\\preferences\\columns.txt";
                //File.Copy(settings, newPreferences, true);
                string contentOfFile = File.ReadAllText(settings); //Es el contenido del archivo
                string newContent = string.Empty;
                int finalLine = 0;
                foreach (string c in contentOfFile.Split('\n')) //Para cada columna
                {
                    finalLine++;
                    if (!string.IsNullOrWhiteSpace(c)) //Que no sea nula, espacio o vacía
                    {
                        char newActive = '0';
                        string colName = c.Split('|')[0];
                        bool active = (c.Split('|')[1][0] != '0'); //Asignamos si será visible o no
                        string tipoDato = c.Split('|')[2].Trim(); //Asignamos el tipo de dato de la columna
                        if (XMLDataGridView.Columns[colName].Visible)
                            newActive = '1';
                        if (finalLine == contentOfFile.Split('\n').Length)
                            newContent += colName + "|" + newActive + "|" + tipoDato;
                        else
                            newContent += colName + "|" + newActive + "|" + tipoDato + "\n";
                    }
                }
                File.WriteAllText(newPreferences, newContent);
            }
        }

        //  *** FUNCIONES ***   \\
        private void ReadFile(string file) //Función que lee un archivo
        {
            Comprobante factura = new Comprobante();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Comprobante));
                XmlTextReader xmlFile = new XmlTextReader(file);
                factura = (Comprobante)serializer.Deserialize(xmlFile);
                xmlFile.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message, "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            XMLDataGridView.Rows.Add();
            AppendRowToGrid(factura);
            InsertXMLNameInGrid(file, XMLDataGridView.RowCount - 1); //Inserta su nombre al final del grid
            if (!Preferencias && !Default)
                EditGroupBox.Text = "Editar columnas (" + ColumnasCheckedListBox.Items.Count.ToString() + ")"; //No es necesario si existe el archivo de prefencias
        }

        private string GetConceptos(Comprobante factura) //Devuelve un string concatenado con los conceptos
        {
            string Concepto = string.Empty;
            for (int i = 0; i < factura.Conceptos.Length; i++)
            {
                if (i > 0)
                    Concepto += " * " + factura.Conceptos[i].Descripcion;
                else
                    Concepto += factura.Conceptos[i].Descripcion;
            }
            return Concepto;
        }

        private string GetUUIDRelacion(Comprobante factura) //Concatena los UUID y el tipo de relación
        {
            string uuidR = string.Empty;
            try
            {
                for(int i = 0; i < factura.CfdiRelacionados.CfdiRelacionado.Length; i++)
                {
                    if (i == 0)
                        uuidR = factura.CfdiRelacionados.TipoRelacion + " - " + factura.CfdiRelacionados.CfdiRelacionado[i].UUID;
                    else
                        uuidR += " * " + factura.CfdiRelacionados.CfdiRelacionado[i].UUID;
                }
            }
            catch (Exception e)
            {
                uuidR = "-";
                Console.WriteLine(e.Message);
            }
            return uuidR;
        }

        public string ReplaceKeyValue(string path, string key) //Reemplaza una clave por su valor
        {
            string txt = File.ReadAllText(path);
            string newKey = key;
            foreach (string line in txt.Split('\n'))
            {
                string clave = line.Split('|')[0];
                string valor = line.Split('|')[1].Replace("\r", string.Empty);
                if (clave == key)
                {
                    newKey = key + " - " + valor;
                    break;
                }
            }
            return newKey;
        }

        private string ReplaceFormaDePago(string formaDePago) //Reemplaza la clave de la forma de pago por la cadena completa
        {
            if (File.Exists(RootPath + @"\\backup\\settings\\keys\\c_FormaPago.txt"))
                formaDePago = ReplaceKeyValue(RootPath + @"\\backup\\settings\\keys\\c_FormaPago.txt", formaDePago);
            return formaDePago;
        }

        private string ReplaceMetodoPago(string metodoPago) //Reemplaza la clave del método de pago por la cadena completa
        {
            if (File.Exists(RootPath + @"\\backup\\settings\\keys\\c_MetodoPago.txt"))
                metodoPago = ReplaceKeyValue(RootPath + @"\\backup\\settings\\keys\\c_MetodoPago.txt", metodoPago);
            return metodoPago;
        }

        private string ReplaceUsoCFDI(string usocfdi) //Reemplaza la clave del uso del CDFI por la cadena completa
        {
            if (File.Exists(RootPath + @"\\backup\\settings\\keys\\c_UsoCFDI.txt"))
                usocfdi = ReplaceKeyValue(RootPath + @"\\backup\\settings\\keys\\c_UsoCFDI.txt", usocfdi);
            return usocfdi;
        }

        private string ReplaceMoneda(string moneda) //Reemplaza la clave de la moneda por la cadena completa
        {
            if (File.Exists(RootPath + @"\\backup\\settings\\keys\\c_Moneda.txt"))
                moneda = ReplaceKeyValue(RootPath + @"\\backup\\settings\\keys\\c_Moneda.txt", moneda);
            return moneda;
        }

        private string ReplaceTipoDeComprobante(string tipoComprobante) //Reemplaza la clave del tipo del comprobante por la cadena completa
        {
            if (File.Exists(RootPath + @"\\backup\\settings\\keys\\c_TipoDeComprobante.txt"))
                tipoComprobante = ReplaceKeyValue(RootPath + @"\\backup\\settings\\keys\\c_TipoDeComprobante.txt", tipoComprobante);
            return tipoComprobante;
        }

        private decimal[] GetImpuestos(Comprobante factura, string tipo)
        {
            decimal iva = 0;
            decimal ieps = 0;
            decimal isr = 0;
            if (factura.Impuestos != null && tipo == "Traslado")
            {
                if (factura.Impuestos.Traslados != null)
                    foreach (ComprobanteImpuestosTraslado impuestoTrasladado in factura.Impuestos.Traslados)
                    {
                        if (impuestoTrasladado.Impuesto == "001")
                            isr += impuestoTrasladado.Importe;
                        else if (impuestoTrasladado.Impuesto == "002")
                            iva += impuestoTrasladado.Importe;
                        else if (impuestoTrasladado.Impuesto == "003")
                            ieps += impuestoTrasladado.Importe;
                    }
            }
            else if (factura.Impuestos != null && tipo == "Retenido")
            {
                if (factura.Impuestos.Retenciones != null)
                    foreach (ComprobanteImpuestosRetencion impuestoRetenido in factura.Impuestos.Retenciones)
                    {
                        if (impuestoRetenido.Impuesto == "001")
                            isr += impuestoRetenido.Importe;
                        else if (impuestoRetenido.Impuesto == "002")
                            iva += impuestoRetenido.Importe;
                        else if (impuestoRetenido.Impuesto == "003")
                            ieps += impuestoRetenido.Importe;
                    }
            }
            decimal[] impuestos = new decimal[3];
            impuestos[0] = isr;
            impuestos[1] = iva;
            impuestos[2] = ieps;
            return impuestos;
        }

        private decimal GetTotalImpuestosTrasladados(ComprobanteImpuestos impuestos)
        {
            if (impuestos != null)
                return impuestos.TotalImpuestosTrasladados;
            return 0;
        }

        private decimal GetTotalImpuestosRetenidos(ComprobanteImpuestos impuestos)
        {
            if (impuestos != null)
                return impuestos.TotalImpuestosRetenidos;
            return 0;
        }

        private void ExportGridToCSV() //Exporta el grid a un csv
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV (*.csv)|*.csv"; //Filtro de archivos
            sfd.FileName = OutFileNameTextBox.Text + ".csv"; //Carga el nombre que se asignó en el textbox
            sfd.Title = "Guardar como archivo csv"; //Texto de la ventana
            sfd.DefaultExt = ".csv"; //Extensión por defecto
            sfd.ValidateNames = true; //Valida el nombre del archivo
            bool fileError = false; 
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(sfd.FileName))
                {
                    try
                    {
                        File.Delete(sfd.FileName); //Elimina el archivo existente
                    }
                    catch (IOException ex)
                    {
                        fileError = true;
                        MessageBox.Show("No fue posible eliminar el archivo anterior. " + ex.Message);
                    }
                }
                if (!fileError) //Si no hay problemas con sobreescribir el archivo
                {
                    try
                    {
                        string[] outputCsv = new string[XMLDataGridView.Rows.Count + 1];
                        for (int i = 0; i < XMLDataGridView.ColumnCount; i++) //For para guardar el nombre de las columnas en la primer línea del archivo
                        {
                            if(XMLDataGridView.Columns[i].Visible == true) //Sólo si la columna es visible
                                outputCsv[0] += XMLDataGridView.Columns[i].HeaderText.ToString().Replace(',', ';') + ","; 
                        }
                        for (int i = 0; i < XMLDataGridView.RowCount; i++) //For para guardar fila por fila
                        {
                            bool colIsVisible = false; //Auxiliar para saber si la columna es visible
                            for (int j = 0; j < XMLDataGridView.ColumnCount; j++)
                            {
                                if (XMLDataGridView.Columns[j].Visible == true)
                                {
                                    outputCsv[i + 1] += XMLDataGridView[j, i].Value.ToString().Replace(',', ';') + ",";
                                }
                            }
                            if (colIsVisible)
                                outputCsv[i + 1] += "\r";
                            ExportProgressBar.PerformStep();
                        }
                        File.WriteAllLines(sfd.FileName, outputCsv, Encoding.UTF8);
                        MessageBox.Show("Se guardó el archivo con éxito", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error :" + ex.Message);
                    }
                }
            }
        }

        private void ExportGridToXLSX() //Exporta el grid a un archivo de excel
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel (*.xlsx)|*.xlsx";
            sfd.FileName = OutFileNameTextBox.Text + ".xlsx";
            sfd.Title = "Guardar como archivo de excel";
            sfd.DefaultExt = ".xlsx";
            sfd.ValidateNames = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                try
                {
                    app.Visible = false;
                    worksheet = workbook.Sheets[1];
                    worksheet = workbook.ActiveSheet;
                    worksheet.Columns.AutoFit();
                    for (int i = 0; i < XMLDataGridView.ColumnCount; i++)
                    {
                        if(XMLDataGridView.Columns[i].Visible == true)
                            worksheet.Cells[1, i + 1] = XMLDataGridView.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < XMLDataGridView.RowCount; i++)
                    {
                        for (int j = 0; j < XMLDataGridView.ColumnCount; j++)
                        {
                            if (XMLDataGridView.Columns[j].Visible == true)
                            {
                                if (XMLDataGridView[j, i].Value != null || XMLDataGridView[j, i].Value.ToString() != "-")
                                {
                                    worksheet.Cells[i + 2, j + 1] = XMLDataGridView[j, i].Value.ToString();
                                }
                                else
                                {
                                    worksheet.Cells[i + 2, j + 1] = "";
                                }
                            }
                        }
                        ExportProgressBar.PerformStep();
                    }
                    MessageBox.Show("El archivo fue exportado con éxito.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("¿Deseas abrir el archivo generado?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        workbook.SaveAs(sfd.FileName);
                        workbook.Saved = true;
                        app.Visible = true;
                    }
                    else
                    {
                        workbook.SaveAs(sfd.FileName);
                        workbook.Saved = true;
                        workbook.Close(true, sfd.FileName);
                    }
                }
                catch (Exception e)
                {
                    workbook.Close(false);
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void ExportGridFast() //Exporta el grid rápidamente a un archivo de excel (experimental)
        {
            // TODO: Ajustar ancho de columnas, eliminar la columna A de excel (está vacía)
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel (*.xlsx)|*.xlsx",
                FileName = OutFileNameTextBox.Text + ".xlsx",
                Title = "Guardar como archivo de excel",
                DefaultExt = ".xlsx",
                ValidateNames = true
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XMLDataGridView.SelectAll();
                DataObject dataObj = XMLDataGridView.GetClipboardContent();
                if (dataObj != null)
                    Clipboard.SetDataObject(dataObj);
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                object misValue = System.Reflection.Missing.Value;
                try
                {
                    app.Visible = false;
                    worksheet = workbook.Sheets[1];
                    worksheet = workbook.ActiveSheet;
                    List<DataGridViewColumn> listVisible = new List<DataGridViewColumn>();
                    foreach (DataGridViewColumn col in XMLDataGridView.Columns)
                    {
                        if (col.Visible)
                            listVisible.Add(col);
                    }
                    for (int i = 0; i < listVisible.Count; i++)
                    {
                        worksheet.Cells[1, i + 2] = listVisible[i].HeaderText;
                        ExportProgressBar.PerformStep();
                    }
                    app.Visible = false;
                    worksheet = workbook.Sheets[1];
                    worksheet = workbook.ActiveSheet;
                    Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[2, 1];
                    CR.Select();
                    worksheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                    worksheet.Columns["A"].Delete();
                    worksheet.Columns.AutoFit();
                    ExportProgressBar.Value = ExportProgressBar.Maximum;
                    MessageBox.Show("El archivo fue exportado con éxito.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName); //Elimina el archivo existente
                        }
                        catch (IOException ex)
                        {
                            MessageBox.Show("No fue posible eliminar el archivo anterior. " + ex.Message);
                            return;
                        }
                    }
                    if (MessageBox.Show("¿Deseas abrir el archivo generado?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        workbook.SaveAs(sfd.FileName);
                        workbook.Saved = true;
                        app.Visible = true;
                    }
                    else
                    {
                        workbook.SaveAs(sfd.FileName);
                        workbook.Saved = true;
                        workbook.Close(false);
                    }
                }
                catch (Exception e)
                {
                    workbook.Close(false);
                    MessageBox.Show(e.Message);
                }
                XMLDataGridView.ClearSelection();
            }
        }

        private void ExportGridToText() //Exporta el grid a un archivo de texto
        {

        }

        //  ***  RECORRIDO DE XML COMO ÁRBOL  ***   \\
        private void Preorder(XmlNode nodo)
        {
            if (nodo != null) //Mientras el nodo no sea nulo
            {
                if (nodo.LocalName == "TimbreFiscalDigital")
                    FillTimbre(nodo.Attributes);
                //GetNodeAttributes(nodo); 
                foreach (XmlNode hijo in nodo.ChildNodes) //Recorre sus nodos hijos
                {
                    Preorder(hijo); //Benditos árboles x2
                }
            }
        }

        private void GetNodeAttributes(XmlNode nodo) //Guarda los atributos de un nodo como una columna
        {
            foreach (XmlAttribute att in nodo.Attributes) //Para cada atributo
            {
                //Do something
            }
        }

        private void FillTimbre(XmlAttributeCollection attributes)
        {
            foreach (XmlAttribute att in attributes)
            {
                switch (att.Name)
                {
                    case "Version":
                        auxTimbre.Version = att.Value;
                        break;
                    case "SelloSAT":
                        auxTimbre.SelloSAT = att.Value;
                        break;
                    case "NoCertificadoSAT":
                        auxTimbre.NoCertificadoSAT = att.Value;
                        break;
                    case "SelloCFD":
                        auxTimbre.SelloCFD = att.Value;
                        break;
                    case "RfcProvCertif":
                        auxTimbre.RfcProvCertif = att.Value;
                        break;
                    case "FechaTimbrado":
                        auxTimbre.FechaTimbrado = DateTime.ParseExact(att.Value, "s", CultureInfo.InvariantCulture);
                        break;
                    case "UUID":
                        auxTimbre.UUID = att.Value;
                        break;
                }
            }
        }

        private TimbreFiscalDigital GetTimbre(Comprobante factura) //Recorre los nodos y asigna los valores al timbre
        {
            if (factura.TimbreFiscalDigital != null)
                return factura.TimbreFiscalDigital;

            for (int i = 0; i < factura.Complemento.Length; i++)
            {
                for(int j = 0; j < factura.Complemento[i].Any.Length; j++)
                {
                    Preorder(factura.Complemento[i].Any[j]);
                }
            }
            return auxTimbre;
        }

        //  *** LLENADO DE GRID *** \\
        private void AppendRowToGrid(Comprobante factura) //Llena un row del Grid con la información de la factura
        {
            factura.TimbreFiscalDigital = GetTimbre(factura);
            int row = XMLDataGridView.RowCount - 1;
            foreach(DataGridViewColumn col in XMLDataGridView.Columns)
            {
                switch (col.HeaderText)
                {
                    case "Verificado ó Asoc.":

                        break;
                    case "Estado SAT":

                        break;
                    case "Versión":
                        XMLDataGridView[col.Index, row].Value = factura.Version;
                        break;
                    case "Tipo":
                        XMLDataGridView[col.Index, row].Value = ReplaceTipoDeComprobante(factura.TipoDeComprobante);
                        break;
                    case "Fecha de Emisión":
                        XMLDataGridView[col.Index, row].Value = factura.Fecha;
                        break;
                    case "Fecha de Timbrado":
                        XMLDataGridView[col.Index, row].Value = factura.TimbreFiscalDigital.FechaTimbrado.ToString("s");
                        break;
                    case "Estado de Pago":
                        //Es un complemento
                        break;
                    case "Fecha de Pago":
                        //Es un complemento
                        break;
                    case "Serie":
                        XMLDataGridView[col.Index, row].Value = factura.Serie;
                        break;
                    case "Folio":
                        XMLDataGridView[col.Index, row].Value = factura.Folio;
                        break;
                    case "UUID":
                        XMLDataGridView[col.Index, row].Value = factura.TimbreFiscalDigital.UUID;
                        break;
                    case "UUID Relación":
                        XMLDataGridView[col.Index, row].Value = GetUUIDRelacion(factura);
                        break;
                    case "RFC Emisor":
                        XMLDataGridView[col.Index, row].Value = factura.Emisor.Rfc;
                        break;
                    case "Nombre Emisor":
                        XMLDataGridView[col.Index, row].Value = factura.Emisor.Nombre;
                        break;
                    case "Lugar de Expedición":
                        XMLDataGridView[col.Index, row].Value = factura.LugarExpedicion;
                        break;
                    case "RFC Receptor":
                        XMLDataGridView[col.Index, row].Value = factura.Receptor.Rfc;
                        break;
                    case "Nombre Receptor":
                        XMLDataGridView[col.Index, row].Value = factura.Receptor.Nombre;
                        break;
                    case "Residencia Fiscal":
                        XMLDataGridView[col.Index, row].Value = factura.Receptor.ResidenciaFiscal;
                        break;
                    case "Num Reg Id Trib":
                        //Ni idea
                        break;
                    case "Uso CFDI":
                        XMLDataGridView[col.Index, row].Value = ReplaceUsoCFDI(factura.Receptor.UsoCFDI);
                        break;
                    case "SubTotal":
                        XMLDataGridView[col.Index, row].Value = factura.SubTotal;
                        break;
                    case "Descuento":
                        XMLDataGridView[col.Index, row].Value = factura.Descuento;
                        break;
                    case "Total IEPS":
                        XMLDataGridView[col.Index, row].Value = GetImpuestos(factura, "Traslado")[2];
                        break;
                    case "IVA 16%":
                        XMLDataGridView[col.Index, row].Value = GetImpuestos(factura, "Traslado")[1];
                        break;
                    case "Retenido IVA":
                        XMLDataGridView[col.Index, row].Value = GetImpuestos(factura, "Retenido")[1];
                        break;
                    case "Retenido ISR":
                        XMLDataGridView[col.Index, row].Value = GetImpuestos(factura, "Retenido")[0];
                        break;
                    case "ISH":
                        //Es un complemento
                        break;
                    case "Total":
                        XMLDataGridView[col.Index, row].Value = factura.Total;
                        break;
                    case "Total Original":
                        //Ni idea de qué sea
                        break;
                    case "Total Trasladados":
                        XMLDataGridView[col.Index, row].Value = GetTotalImpuestosTrasladados(factura.Impuestos);
                        break;
                    case "Total Retenidos":
                        XMLDataGridView[col.Index, row].Value = GetTotalImpuestosRetenidos(factura.Impuestos);
                        break;
                    case "Total Local Trasladado":
                        //Es un complemento
                        break;
                    case "Total Local Retenido":
                        //Es un complemento
                        break;
                    case "Moneda":
                        XMLDataGridView[col.Index, row].Value = ReplaceMoneda(factura.Moneda);
                        break;
                    case "Tipo de Cambio":
                        XMLDataGridView[col.Index, row].Value = factura.TipoCambio;
                        break;
                    case "Forma de Pago":
                        XMLDataGridView[col.Index, row].Value = ReplaceFormaDePago(factura.FormaPago);
                        break;
                    case "Método de Pago":
                        XMLDataGridView[col.Index, row].Value = ReplaceMetodoPago(factura.MetodoPago);
                        break;
                    case "NumCtaPago":
                        
                        break;
                    case "Condición de Pago":
                        XMLDataGridView[col.Index, row].Value = factura.CondicionesDePago;
                        break;
                    case "Conceptos":
                        XMLDataGridView[col.Index, row].Value = GetConceptos(factura);
                        break;
                    case "Combustible":

                        break;
                    case "Archivo XML":
                        //Se inserta al momento de leer el archivo
                        break;
                }
            }
        }

        private void InsertXMLNameInGrid(string path, int row) //Inserta el nombre del archivo en la última columna
        {
            string[] XMLName = path.Split('\\'); //Obtén el último nombre del archivo
            XMLDataGridView[XMLDataGridView.ColumnCount - 1, row].Value = XMLName[XMLName.Length - 1]; //Agrégalo al grid
        }

        private void FillGridEmptySpaces() //Llena los campos vacíos con 0 para Doubles o con '-' para strings
        {
            for (var i = 0; i < XMLDataGridView.ColumnCount; i++)
            {
                for (var j = 0; j < XMLDataGridView.RowCount; j++)
                {
                    if (XMLDataGridView.Columns[i].ValueType == typeof(Double) && XMLDataGridView[i, j].Value == null)
                        XMLDataGridView[i, j].Value = 0;
                    else if (XMLDataGridView[i, j].Value == null)
                        XMLDataGridView[i, j].Value = "-";
                }
            }
        }
    }
}
