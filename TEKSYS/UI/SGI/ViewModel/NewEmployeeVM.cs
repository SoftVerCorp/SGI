using Libraries.Video;
using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SGI.ViewModel
{
    public class NewEmployeeVM : ViewModelBase
    {
        #region Private Fields

        private int employeeId;

        private string name;
        private string email;

        private DateTime? hireDate;

        private bool sendNotify;

        //private Image imgVideo;
        private System.Windows.Controls.Image imgCapture;

        // WebCam webcam;

        #endregion

        #region Public Properties

        public event EventHandler OnAddEmployee;

        #endregion

        #region Constructors

        /// <summary>
        ///  Representa una nueva instancia de la clase NewEmployeeVM
        /// </summary>
        public NewEmployeeVM()
        {
            try
            {
                this.OperationType = Enumeration.Operation.Create;
                this.TitleWindow = "Agregar nuevo empleado";
                this.HireDate = DateTime.Now;
                this.SendNotify = false;

            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        ///  Representa una nueva instancia de la clase NewProductVM
        /// </summary>
        public NewEmployeeVM(Empleado param)
        {
            try
            {
                OperationType = Enumeration.Operation.Update;
                this.TitleWindow = "Modificar empleado";

                if (param != null)
                {
                    this.employeeId = param.Id;
                    this.name = param.Nombre;
                    this.hireDate = param.FechaIngreso;
                    this.SendNotify = false;
                    this.Email = param.Email;
                    this.SnapshotTaken = ConvertToImageSource(param.Foto);
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public bool SendNotify
        {
            get { return sendNotify; }
            set
            {
                if (sendNotify != value)
                {
                    sendNotify = value;
                    RaisePropertyChanged(() => SendNotify);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    RaisePropertyChanged(() => Email);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre del empleado.
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la fecha de contratación.
        /// </summary>
        public DateTime? HireDate
        {
            get { return hireDate; }
            set
            {
                if (hireDate != value)
                {
                    hireDate = value;
                    RaisePropertyChanged(() => HireDate);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public ICommand ContentRendered
        {
            get
            {
                return new RelayCommand(this.OnContentRendered);
            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //public ICommand Captured
        //{
        //    get
        //    {
        //        return new RelayCommand(s => this.OnCapture());
        //    }
        //}

        #endregion

        #region Cam Region

        /// <summary>
        /// Video preview width.
        /// </summary>
        private int videoPreviewWidth;

        /// <summary>
        /// Video preview height.
        /// </summary>
        private int videoPreviewHeight;

        /// <summary>
        /// Selected video device.
        /// </summary>
        private MediaInformation selectedVideoDevice;

        /// <summary>
        /// Snapshot taken.
        /// </summary>
        private ImageSource snapshotTaken;

        /// <summary>
        /// Byte array of snapshot image.
        /// </summary>
        private Bitmap snapshotBitmap;

        /// <summary>
        /// List of media information device available.
        /// </summary>
        private IEnumerable<MediaInformation> mediaDeviceList;



        /// <summary>
        /// Instance of relay command for snapshot command.
        /// </summary>
        private RelayCommand snapshotCommand;


        /// <summary>
        /// Gets or sets media device list.
        /// </summary>
        public IEnumerable<MediaInformation> MediaDeviceList
        {
            get
            {
                return this.mediaDeviceList;
            }

            set
            {
                this.mediaDeviceList = value;
                this.RaisePropertyChanged(() => this.MediaDeviceList);
            }
        }

        /// <summary>
        /// Gets or sets video preview width.
        /// </summary>
        public int VideoPreviewWidth
        {
            get
            {
                return this.videoPreviewWidth;
            }

            set
            {
                this.videoPreviewWidth = value;
                this.RaisePropertyChanged(() => this.VideoPreviewWidth);
            }
        }

        /// <summary>
        /// Gets or sets video preview height.
        /// </summary>
        public int VideoPreviewHeight
        {
            get
            {
                return this.videoPreviewHeight;
            }

            set
            {
                this.videoPreviewHeight = value;
                this.RaisePropertyChanged(() => this.VideoPreviewHeight);
            }
        }

        /// <summary>
        /// Gets or sets selected media video device.
        /// </summary>
        public MediaInformation SelectedVideoDevice
        {
            get
            {
                return this.selectedVideoDevice;
            }

            set
            {
                this.selectedVideoDevice = value;
                this.RaisePropertyChanged(() => this.SelectedVideoDevice);
            }
        }

        /// <summary>
        /// Gets or sets image source.
        /// </summary>
        public ImageSource SnapshotTaken
        {
            get
            {
                return this.snapshotTaken;
            }

            set
            {
                this.snapshotTaken = value;
                this.RaisePropertyChanged(() => this.SnapshotTaken);
            }
        }

        /// <summary>
        /// Gets or sets snapshot bitmap.
        /// </summary>
        public Bitmap SnapshotBitmap
        {
            get
            {
                return this.snapshotBitmap;
            }

            set
            {
                this.snapshotBitmap = value;
                this.RaisePropertyChanged(() => this.SnapshotBitmap);
            }
        }

        /// <summary>
        /// Gets instance of relay command for snapshot command.
        /// </summary>
        public RelayCommand SnapshotCommand
        {
            get
            {
                return this.snapshotCommand = new RelayCommand(s => this.OnSnapshot());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Event handler for on take snapshot command click.
        /// </summary>
        private void OnSnapshot()
        {
            this.SnapshotTaken = ConvertToImageSource(this.SnapshotBitmap);
        }

        /// <summary>
        /// The convert to image source.
        /// </summary>
        /// <param name="bitmap"> The bitmap. </param>
        /// <returns> The <see cref="object"/>. </returns>
        public static ImageSource ConvertToImageSource(Bitmap bitmap)
        {
            var imageSourceConverter = new ImageSourceConverter();
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    bitmap.Save(memoryStream, ImageFormat.Png);
                    var snapshotBytes = memoryStream.ToArray();
                    return (ImageSource)imageSourceConverter.ConvertFrom(snapshotBytes); ;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private ImageSource ConvertToImageSource(string path)
        {
            try
            {
                Uri uri = null;

                if (string.IsNullOrEmpty(path))
                {
                    path = "/Resources/Images/withoutimage.png";
                }

                uri = new Uri(path, UriKind.RelativeOrAbsolute);
                ImageSource imgSource = new BitmapImage(uri);
                return imgSource;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param">arreglo de parametros que contiene los controles para tomar fotografia</param>
        private void OnContentRendered(object param)
        {
            try
            {
                if (param != null)
                {
                    imgCapture = param as System.Windows.Controls.Image;

                    if (imgCapture != null)
                    {
                        //this.imgVideo = array[0] as Image;
                        //this.imgCapture = array[1] as Image;

                        this.MediaDeviceList = WebcamDevice.GetVideoDevices;
                        this.VideoPreviewWidth = 320;
                        this.VideoPreviewHeight = 240;

                        if (this.MediaDeviceList != null)
                        {
                            if (this.MediaDeviceList.Count() > 0)
                            {
                                this.SelectedVideoDevice = MediaDeviceList.FirstOrDefault();
                            }
                        }


                        //webcam = new WebCam();
                        //webcam.InitializeWebCam(ref imgVideo);
                        //webcam.Start();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private void OnCapture()
        //{
        //    try
        //    {
        //        imgCapture.Source = imgVideo.Source;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error capturando imagen" + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        /// <summary>
        /// Guarda un nuevo elemento en el catalogo de productos.
        /// </summary>
        public override void OnAccept()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                MessageBox.Show("Debe ingreasar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!string.IsNullOrEmpty(this.Email))
            {
                if (!VerifyEmail(this.Email))
                {
                    MessageBox.Show("Email incorrecto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            try
            {
                int error = 0;
                string pathImage = string.Empty;
                string errorMessage = string.Empty;

                Empleado model = new Empleado();
                model.Id = this.employeeId;
                model.Nombre = this.Name;
                model.FechaIngreso = this.HireDate;             
                //model.SendNotifications = this.SendNotify;
                model.Email = this.Email;

                try
                {
                    this.SaveImage(ref pathImage);
                    model.Foto = pathImage;
                }
                catch (Exception ex)
                {

                }

                if (this.OperationType == Enumeration.Operation.Create)
                {


                    //var result = Repository.InsEmployee(model, ref error, ref errorMessage);

                    //if (!result)
                    //{
                    //    MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    return;
                    //}

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (OnAddEmployee != null)
                    {
                        OnAddEmployee(true, null);
                    }
                }
                else
                {
                    if (this.OperationType == Enumeration.Operation.Update)
                    {
                        var res = Repository.UpdEmployee(model, ref errorMessage);

                        if (res)
                        {
                            MessageBox.Show("Datos modificados con exito ", "Datos Modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                }

                if (OnAddEmployee != null)
                {
                    OnAddEmployee(this, null);
                }


            }
            catch (Exception ex)
            {

            }
            finally
            {
                OnClose();
            }
        }

        private bool VerifyEmail(string email)
        {
            try
            {
                return Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SaveImage(ref string imagePath)
        {
            try
            {
                if (imgCapture.Source != null)
                {
                    ImageConvert.SaveImageCapture((BitmapSource)imgCapture.Source, ref imagePath);
                }
                //ImageConvert.SaveImageCapture((BitmapSource)imgCapture.Source);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando la imagen ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void SaveImage()
        {
            try
            {
                if (imgCapture.Source != null)
                {
                    ImageConvert.SaveImageCapture((BitmapSource)imgCapture.Source);
                }
                //ImageConvert.SaveImageCapture((BitmapSource)imgCapture.Source);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error guardando la imagen ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Cierra la ventana
        /// </summary>
        public override void OnClose()
        {
            try
            {
                if (thisWindow != null)
                {
                    this.thisWindow.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Limpiar los controles.
        /// </summary>

        private void Clean()
        {

        }

        #endregion
    }
}