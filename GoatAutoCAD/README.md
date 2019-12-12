
#
    出现 类型“System.Windows.Markup.IQueryAmbient”在未被引用的程序集中定义。必
    解决： 在程序中添加 System.Xaml.dll 引用即可解决。


#
    九个固定的符号表
    命名对像字典（包含Group字典和Mline样式字典）



#
    9种符号表：

    1)块表(BlockTabLe)

    2)尺寸标注样式表(DimStyleTable)

    3)层表(LayerTable)

    4)线型表(LinetypeTable)

    5)应用程序注册表(RegAppTable)

    6)文字样式表(TextStyleTable)

    7)用户坐标系表(UCSTable)

    8)视口表(ViewportTable)

    9)视图表(ViewTable)

#
Application
    DocumentManager

# Application 对象层次 ： 通过 Application 对象，用户可以访问主窗口以及任何打开的图形。

     DocumentManager ： 该对象提供对AutoCAD中当前图形的访问并允许用户并允许用户创建、保存和打开图形文件。包含所有的document对象（每一个打开的图形都有一个对应的document对象）

     Document WindowCollection： 包括所有的document窗口对象（再 documentManger中每一个document对象都有一个document窗口）

     InfoCenter： 包括对信息中心工具栏的引用

     MainWindows：  包含对 AutoCAD 应用程序窗口对象的引用

     MenuBar：  包含对 AutoCAD 菜单栏对应的COM菜单栏对象的引用

     Menu Groups  包含COM的菜单组对应的引用，它包含每一个加载的CUIX文件的定制组名。

     Preferences 包含COM的参数选项对象的引用，它允许你修改选项 （Options）对话框中的许多设置。

     Publisher 包含 Publisher 对象的引用，它用于发布图形

     StatusBar： 包含应用程序窗口的状态对象的引用

     User configuration  包含UserConfiguration对象的引用，他允许用户保存个人配置

#
    Application
        DocumentManager
            Document
                Database
                Editor
                GraphicsManager
                StatusBar
                TransactionManager
                User Data
                Window


    Application
        DocumentManager
            Document
                 Database
         NameDictionaries               Tables

         layout Dic  Other Dic      Block Table   Other Table
                                    BlockTableRecord   TableRecord
                                    Entity