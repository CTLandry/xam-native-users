# xam-native-users

## Architecture (MVVM)

![API follows Domain Driven Design](https://www.textlocal.com/wp-content/uploads/2016/10/Textlocal-How-to-Guide-How-to-create-a-contact-list-cover.png)

## Functionality

- Contact List View
- Add Contact
- Validate Password Entry

## Dependencies

- MVVMCross
- sql-net-pcl

# iOS

Dropped this project due to some oddities in MvvmCross 6+. All lazy registrations to the IoC container seemed not to be ready at execution. Could not find anything in the documentation that was not added already via the TipCalc example git. Changed to non lazy registration cleared up my user created services but not the internal registrations that MVVMCross usually does itself like Navigation and Cache. 


