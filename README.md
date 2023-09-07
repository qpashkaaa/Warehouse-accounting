# What It This?
  **Desktop App written in C# using C.R.U.D.**
  >*This application was created to master the technologies used and study the Model-View-ViewModel(MVVM) development pattern. The application allows you to create, view, update and delete data in a PostgreSQL database.*

## Preview
### Screenshots
_____
![Preview1](https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/50945271-7662-4367-a156-6b9158d5d247)
_____
![Preview2](https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/0f27ce6f-aa0c-42ed-8e04-2df2dbef5764)
_____
![Preview3](https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/877398bb-2a87-49ed-b9e0-6cdc305ab432)
_____
![Preview4](https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/843703ff-2553-4b5d-8b49-660212264294)
_____

### Demo Video
https://github.com/qpashkaaa/Warehouse-accounting/assets/95401099/901161d0-93a4-4cfb-b18e-02c3c4da8776
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
```C#
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
- [Portfolio Website]()
- [Telegram](https://t.me/qpashkaaa)
- [VK](https://vk.com/qpashkaaa)
- [LinkedIN](https://www.linkedin.com/in/pavel-roslyakov-7b303928b/)

## Year of Development
> *2023*
  
