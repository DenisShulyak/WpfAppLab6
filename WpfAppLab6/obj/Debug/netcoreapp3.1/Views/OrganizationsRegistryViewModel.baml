   M S B A M L   `   `   `  ����E  AWpfAppLab6, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:WpfAppLab6.ViewsWpfAppLab6.Views  5      5    /WpfAppLab6.Views.OrganizationsRegistryViewModel   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      0localclr-namespace:WpfAppLab6.Views     5      -   5          >�Name$  OrganizationsRegistryView��5      .��5      � .+�5   
   �� .+�5      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��5
         
IsReadOnly$
 True��5      ��5      �� *Organizations+ �� ElementName$ OrganizationsRegistryView�� �� SelectedItem 5	      �� *SelectedOrganization+$ OrganizationsRegistryView�� � DataContext 5      �� $ OrganizationsRegistryView��   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name��6)      
IsReadOnly$
 True��6P   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   �� *Name+6P     5      $	 INN��6)   $
 True��6N   	 66   �� *Inn+6N     5      $	 KPP��6)   $
 True��6N   	 66   �� *Kpp+6N     5      $ Address��6)   $
 True��6V   	 6:   �� *	Address+6V     5      $
 City��6)   $
 True��6U   	 67   �� *	City.Name+6U     5      $ Organization Type��6)   $
 True��6n   	 6D   �� *OrganizationType.Name+6n   5      �� 5      
 �� Orientation$
 
Horizontal=�6   $��Right=�62   $��	0,10,10,0q�6N   .+�5      �� -   5        $��Изменить��5      $��0,0,5,0q�6E   �� 5      -   5        $��Удалить��5      $��0,0,5,0q�6F   �� 5      -   5        $��Добавить��5      6,   5      5      5      5      