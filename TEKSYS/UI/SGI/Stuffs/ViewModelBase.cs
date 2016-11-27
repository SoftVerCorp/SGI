namespace SGI.Stuffs
{
    #region Usings

    using SGI.Enumeration;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    #endregion

    public class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        #region private Fields

        private bool isOpenWidth;
        private bool open;
        private Operation operationType;
        private string titleWindow;

        #endregion

        public ViewModelBase()
        {
            this.isOpenWidth = true;
        }

        #region public Properties

        public string TitleWindow
        {
            get { return titleWindow; }
            set
            {
                if (titleWindow != value)
                {
                    titleWindow = value;
                    RaisePropertyChanged(() => TitleWindow);
                }
            }
        }

        public Operation OperationType
        {
            get { return operationType; }
            set { operationType = value; }
        }

        public Window thisWindow;

        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene el comando que indica que la ventana inicializo
        /// </summary>
        public ICommand Loaded
        {
            get
            {
                return new RelayCommand(OnLoaded);
            }
        }

        /// <summary>
        /// Obtiene el comando que cerrara la ventana
        /// </summary>
        public ICommand Close
        {
            get
            {
                return new RelayCommand(s => OnClose());
            }
        }

        /// <summary>
        /// Obtiene el comando que cerrara la ventana
        /// </summary>
        public ICommand Accept
        {
            get
            {
                return new RelayCommand(s => OnAccept());
            }
        }

        /// <summary>
        /// Obtiene el comando que cerrara la ventana
        /// </summary>
        public ICommand RefreshSearch
        {
            get
            {
                return new RelayCommand(s => OnRefreshSearch());
            }
        }

        public bool IsOpen
        {
            get
            {
                return this.open;
            }
            set
            {
                if (this.open != value)
                {
                    this.open = value;
                    RaisePropertyChanged(() => IsOpen);
                }
                //this.OnPropertyChanged("IsOpen");
            }
        }



        public ICommand DeleteItem
        {
            get
            {
                return new RelayCommand(OnDeleteItem);
            }
        }

        public ICommand UpdateItem
        {
            get
            {
                return new RelayCommand(OnUpdateItem);
            }
        }

        public ICommand AddItem
        {
            get
            {
                return new RelayCommand(OnAddItem);


            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand Clean
        {
            get
            {
                return new RelayCommand(s => OnClean());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand SelectedITemGridClick
        {
            get
            {
                return new RelayCommand(OnSelectedItemGridClick);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand OpenWidthCommand
        {
            get
            {
                return new RelayCommand(s => OnOpenWidth());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsOpenWidth
        {
            get { return isOpenWidth; }
            set
            {
                if (isOpenWidth != value)
                {
                    isOpenWidth = value;
                    RaisePropertyChanged(() => IsOpenWidth);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand Save
        {
            get
            {
                return new RelayCommand(s => OnSave());
            }
        }

        public ICommand ExportarCmd
        {
            get
            {
                return new RelayCommand(s => ExportarExcel());
            }
        }

        #endregion

        #region Private Methods

        public virtual void ExportarExcel()
        {

        }

        public virtual void OnSave()
        {

        }

        private void OnOpenWidth()
        {
            if (this.IsOpenWidth)
            {
                IsOpenWidth = false;
            }
            else
            {
                IsOpenWidth = true;
            }
        }

        public virtual void OnSelectedItemGridClick(object parameters)
        {

        }

        public virtual void OnClean()
        {

        }

        public virtual void OnAddItem(object param)
        {

        }

        public virtual void OnDeleteItem(object param)
        {

        }

        public virtual void OnUpdateItem(object param)
        {

        }


        public virtual void OnAccept()
        {

        }

        public virtual void OnRefreshSearch()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public virtual void OnLoaded(object param)
        {
            try
            {
                thisWindow = param as Window;
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Cierra la ventana
        /// </summary>
        public virtual void OnClose()
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
        /// Cierra la ventana
        /// </summary>
        public virtual void OnCloseMainWindow()
        {
            try
            {
                Application.Current.MainWindow.Close();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed
        /// </summary>
        /// <param name="propertyExpression">property</param>
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            var body = propertyExpression.Body as MemberExpression;
            if (body != null)
            {
                var property = body.Member as PropertyInfo;
                if (property != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(property.Name));
                }
            }
        }

        #endregion

        #region Dispose

        ~ViewModelBase()
        {
            // the finalizer also has to release unmanaged resources,
            // in case the developer forgot to dispose the object.
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);

            // this tells the garbage collector not to execute the finalizer
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // clean up managed resources:
                // dispose child objects that implement IDisposable
            }
        }


        #endregion
    }
}

