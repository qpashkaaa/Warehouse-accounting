# What It This?
  **Desktop App written in C# using C.R.U.D.**
  >*This application was created to master the technologies used and study the Model-View-ViewModel(MVVM) development pattern. The application allows you to create, view, update and delete data in a PostgreSQL database.*

## Preview
### Screenshots
_____
![Screenshot_1](https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/b95121f7-486d-467b-83df-37c7caeb0292)
_____
![Screenshot_2](https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/0e1df69d-59bb-4091-a4ae-d0139746f550)
_____
![Screenshot_3](https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/f8194edd-2a9a-401c-a710-031cf9ceb7ae)
_____
![Screenshot_4](https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/524bc834-b09b-45a8-8d2d-959c3fbaea9f)
_____

### Demo Video
https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/1bd2b2af-5e4f-430c-a5ba-b1fe3f6142b2
_____


## Features
- **Performing basic functions for working with databases : CREATE, READ, UPDATE, DELETE.**
- **Algorithmic encryption and password decryption during registration and authorization.**
```C#
public static String AES_encrypt(String input)
        {
            RijndaelManaged aes = new RijndaelManaged();
            aes.KeySize = keyLength;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            aes.Key = mkey(key, keyLength);
            aes.IV = mkey(Iv, 128);

            var encrypt = aes.CreateEncryptor(aes.Key, aes.IV);
            byte[] xBuff = null;

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, encrypt, CryptoStreamMode.Write))
                {
                    byte[] xXml = Encoding.UTF8.GetBytes(input);
                    cs.Write(xXml, 0, xXml.Length);
                    cs.FlushFinalBlock();
                }

                xBuff = ms.ToArray();
            }

            return Convert.ToBase64String(xBuff, Base64FormattingOptions.None);
        }
```
- **A component-oriented architecture built on the interaction of multiple User Сontrols that perform their functions.**
```XAML
<UserControl x:Class="Warehouse_accounting.View.Components.CustomDataGridInfoBox"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:Warehouse_accounting.View.Components"
             mc:Ignorable="d"
             x:Name="dg_InfoBox">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"></ColumnDefinition>
            <ColumnDefinition Width="Auto"></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <TextBlock Grid.Column="0" x:Name="cellPlaceholder" Text="{Binding ElementName=dg_InfoBox, Path=TableName, UpdateSourceTrigger=PropertyChanged}" FontSize="24" FontWeight="Medium" VerticalAlignment="Center" HorizontalAlignment="Left" Panel.ZIndex="-1" Foreground="#091E42"/>
        <Border Grid.Column="1"
            CornerRadius="50" Background="#F9F5FF" Width="22" Height="22" Margin="10 0 10 0">
            <TextBlock x:Name="dtGridElementsCount" Text="{Binding ElementName=dg_InfoBox, Path=CountTableElements, UpdateSourceTrigger=PropertyChanged}" FontSize="12" FontWeight="Medium" VerticalAlignment="Center" HorizontalAlignment="Center" Panel.ZIndex="-1" Foreground="#93312B"/>
        </Border>
    </Grid>
</UserControl>
```
```C#
public partial class CustomDataGridInfoBox : UserControl
    {
        public CustomDataGridInfoBox()
        {
            InitializeComponent();
        }

        public static DependencyProperty TableNameProperty = DependencyProperty.Register(
            "TableName",
            typeof(string),
            typeof(CustomDataGridInfoBox),
            new FrameworkPropertyMetadata(
            null, // default value
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string TableName
        {
            get { return (string)GetValue(TableNameProperty); }
            set { SetValue(TableNameProperty, value); }
        }

        public static DependencyProperty CountTableElementsProperty = DependencyProperty.Register(
            "CountTableElements",
            typeof(int),
            typeof(CustomDataGridInfoBox),
            new FrameworkPropertyMetadata(
            0, // default value
            FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public int CountTableElements
        {
            get { return (int)GetValue(CountTableElementsProperty); }
            set { SetValue(CountTableElementsProperty, value); }
        }
    }
```

## Tech Stack
- **С# WPF(MVVM)**
- **Entity Framework**
- **PostgreSQL (Database)**

## Requirements
- **NuGet Packages**
  - ```Microsoft.EntityFrameworkCore```
  - ```Microsoft.EntityFrameworkCore.Tools```
  - ```Microsoft.Extensions.Configuration```
  - ```Microsoft.Extensions.Configuration.Json```
  - ```Microsoft.Extensions.DependencyInjection```
  - ```Microsoft.Xaml.Behaviors.Wpf```
  - ```MvvmLightLibs```
  - ```Npgsql.EntityFrameworkCore.PostgreSQL```

## Authors
- [Pavel Roslyakov](https://github.com/qpashkaaa)

## Contacts
- [Portfolio Website](https://portfolio-website-qpashkaaa.vercel.app/)
- [Telegram](https://t.me/qpashkaaa)
- [VK](https://vk.com/qpashkaaa)
- [LinkedIN](https://www.linkedin.com/in/pavel-roslyakov-7b303928b/)

## Year of Development
> *2023*
  
