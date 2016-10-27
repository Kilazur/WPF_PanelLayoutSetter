# WPF_PanelLayoutSetter
Simple helper class to automatically set some properties for all the contained elements of a Panel class (including the obvious Grid).

### Due credits:

#### The original idea:
http://blogs.microsoft.co.il/eladkatz/2011/05/29/what-is-the-easiest-way-to-set-spacing-between-items-in-stackpanel/

Provides the base class that allows to set a single property (Margin) to all children of a Panel.
There are two issues:

 - There is not check for the value being already set in XAML, so it's overwritten.
 - If you add some other properties, they'll all be set (to default value) even if only one is set on the Panel.
 
#### The solution:
http://stackoverflow.com/a/19798648/3283203

You just have to know it. It allows to check weither a value has been set in XAML or not, allowing the Panel's elements to overwrite LayoutSetter's properties if needed.
