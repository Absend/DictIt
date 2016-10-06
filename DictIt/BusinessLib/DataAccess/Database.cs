using BusinessLib.DataModel;

namespace BusinessLib.DataAccess
{
    /// <summary>
    /// A data source that provides raw data objects.  In a real
    /// application this class would make calls to a database.
    /// </summary>
    public static class Database
    {

        #region GetFamilyTree

        public static Person GetFamilyTree()
        {
            // In a real app this method would access a database.
            return new Person
            {
                Name = "WFP Fundamentals - XAML Basics",
                Children =
                {
                    new Person
                    {
                        #region intro
                        Name = "Introduction",
                        Children =
                        {
                            new Person
                            {
                                Name = "01. Introduction.wmv",
                            },
                            new Person
                            {
                                Name = "02. What is WPF.wmv",
                            },
                            new Person
                            {
                                Name = "03. Why WPF.wmv",
                            },
                            new Person
                            {
                                Name = "04. Integration.wmv",
                            },
                            new Person
                            {
                                Name = "05. WPF Design.wmv",
                            },
                            new Person
                            {
                                Name = "06. Xaml.wmv",
                            },
                            new Person
                            {
                                Name = "07. UI Tree.wmv",
                            },
                            new Person
                            {
                                Name = "08. Events and Commands.wmv",
                            },
                            new Person
                            {
                                Name = "09. Controls.wmv",
                            },
                            new Person
                            {
                                Name = "10. Primitive Elements.wmv",
                            },
                            new Person
                            {
                                Name = "11. Layout.wmv",
                            },
                            new Person
                            {
                                Name = "12. Flowed Text.wmv",
                            },
                            new Person
                            {
                                Name = "13. Data.wmv",
                            },
                            new Person
                            {
                                Name = "14. Deployment.wmv",
                            },
                            new Person
                            {
                                Name = "15. Silverlight.wmv",
                            },
                            new Person
                            {
                                Name = "16. Designers.wmv",
                            },
                            new Person
                            {
                                Name = "17. Summary.wmv",
                            }
                        }
                    },

                    #endregion                      
                    new Person
                    {
                        #region Controls              
                        Name = "Controls",
                        Children =
                        {
                            new Person
                            {
                                Name = "01. Controls.wmv",
                            },
                            new Person
                            {
                                Name = "02. Outline.wmv"
                            },
                            new Person
                            {
                                Name = "03. Buttons.wmv"
                            },
                            new Person
                            {
                                Name = "04. Content Model.wmv"
                            },
                            new Person
                            {
                                Name = "05. Grouping Controls.wmv"
                            },
                            new Person
                            {
                                Name = "06. Text Input.wmv"
                            },
                            new Person
                            {
                                Name = "07. Range Controls.wmv"
                            },
                            new Person
                            {
                                Name = "08. Items Controls.wmv"
                            },
                            new Person
                            {
                                Name = "09. More Items Controls.wmv"
                            },
                            new Person
                            {
                                Name = "10. Item Controls and Content Models.wmv"
                            },
                            new Person
                            {
                                Name = "11. Item Containers.wmv"
                            },
                            new Person
                            {
                                Name = "12. Controls vs Elements.wmv"
                            },
                            new Person
                            {
                                Name = "13. Events and Commands.wmv"
                            },
                            new Person
                            {
                                Name = "14. Event Routing.wmv"
                            },
                            new Person
                            {
                                Name = "15. Built-in Commands.wmv"
                            },
                            new Person
                            {
                                Name = "16. Menus and Commands.wmv"
                            }
                        }
                    },
                    new Person
                    {
                        Name = "Layout",
                        Children =
                        {
                            new Person
                            {
                                Name = "01. Layout.wmv",
                            },
                            new Person
                            {
                                Name = "02. Layout Process.wmv"
                            },
                            new Person
                            {
                                Name = "03. Declarative Layout.wmv"
                            },
                            new Person
                            {
                                Name = "04. Margin"
                            },
                            new Person
                            {
                                Name = "05. Padding.wmv"
                            },
                            new Person
                            {
                                Name = "06. Alignment.wmv"
                            },
                            new Person
                            {
                                Name = "07. Content Alignment.wmv"
                            },
                            new Person
                            {
                                Name = "08. Explicit Width and Height.wmv"
                            },
                            new Person
                            {
                                Name = "09. Grid.wmv"
                            },
                            new Person
                            {
                                Name = "10. GridSplitter.wmv"
                            },
                            new Person
                            {
                                Name = "11. DockPanel, StackPanel, WrapPanel.wmv"
                            },
                            new Person
                            {
                                Name = "12. Canvas.wmv"
                            },
                            new Person
                            {
                                Name = "13. ScrollViewer.wmv"
                            },
                            new Person
                            {
                                Name = "14. Viewbox.wmv"
                            },
                            new Person
                            {
                                Name = "15. Windows.wmv"
                            },
                            new Person
                            {
                                Name = "16. Navigation.wmv"
                            },
                            new Person
                            {
                                Name = "17. Summary.wmv"
                            }
                            #endregion
                        }
                    }
                }
                #endregion // GetFamilyTree
            };
        }
    }
}