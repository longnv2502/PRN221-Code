   M S B A M L   `   `   `  ????G  CMVVMEmployee, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MVVMEmployee.ViewsMVVMEmployee.Views  5   	   %    MVVMEmployee.Views.EmployeeView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MVVMEmployee.Views     5   	     ? Title$  EmployeeView??5   	   $	??500??6   $	??525??6+   .??5	      ? $??15q?6    ? ColumnDefinitions 5
   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   .+?5   
   ?? $??Employee Management??6   $??0??5      $??0??5      $??2??5      $??20(?5      $
??Bold"?5      $??Center=?5      $	??5,8q?5       ?? Padding$ 3q?5       ?? 5!   
   $??Enter Id??6   $??1??5"      $??0??5#      $	??5,8q?5$      $ 3q?5%      ?? 5&   
   $??
Enter Name??6   $??2??5'      $??0??5(      $	??5,8q?5)      $ 3q?5*      ?? 5+   
   $??	Enter Age??6   $??3??5,      $??0??5-      $	??5,8q?5.      $ 3q?5/      ?? 51   
   -   5        $??txtId??51      $??1??52      $??1??53      $	??5,8q?54      $??3q?55      ??56      ??  ?? Path$ CurrentEmployee.Id? ?? Mode$ TwoWay=??? 57   
   -   5        $??txtName??57      $??2??58      $??1??59      $	??5,8q?5:      $??3q?5;      ??5<      ?? $ CurrentEmployee.Name?$ TwoWay=??? 5=   
   -   5        $??txtAge??5=      $??3??5>      $??1??5?      $	??5,8q?5@      $??3q?5A      ??5B      ?? $ CurrentEmployee.Age?$ TwoWay=??? 5D   
    ?? Orientation$ 
Horizontal=?6   $??4??5E      $??1??5F      .+?5G      ?? -   5        $??btnAdd??5G      $	??ADD??5H      $	??5,8q?5I      $??3q?5J      ??5K      ?? $ SaveCommand??? 5L      -   5        $??	btnSearch??5L      $??SEARCH??5M      $	??5,8q?5N      $??3q?5O      ??5P      ?? $ SearchCommand??? 5Q      -   5        $??	btnUpdate??5Q      $??UPDATE??5R      $	??5,8q?5S      $??3q?5T      ??5U      ?? $ UpdateCommand??? 5V      -   5        $??	btnDelete??5V      $??DELETE??5W      $	??5,8q?5X      $??3q?5Y      ??5Z      ?? $ DeleteCommand?5[      ?? 5\   
   -   5        $??txtBlockMessage??5\      $??5??5]      $??1??5^      $	??5,8q?5_      $ 3q?5`      ??5a      ?? $ Message?&   System.Windows.Controls.DataGrid  5b   
   -	   5        $??dgEmployees??5b         AutoGenerateColumns$ False??5c      $??6??5d      $??1??5e      $	??5,8q?5f      $??3q?5g      ??5h      ?? $ EmployeesList?$ TwoWay=?   Columns 5i      0  *System.Windows.Controls.DataGridTextColumn  5j      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Employee Id??6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 auto 5k   %   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5l   %   ?? $ Id?  5m      $	 Employee Name??6%   $

 auto 5n   %    5o   %   ?? $
 Name?  5p      $	 Employee Age??6%   $

 auto 5q   %    5r   %   ?? $	 Age?5t      5u      5v      