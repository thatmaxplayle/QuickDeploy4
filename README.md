# QuickDeploy4
The open-source version (rewrite WIP) the local file deployment tool I wrote and use myself. 

## What is QuickDeploy?
I wrote this tool whilst writing my LSPDFR Callout Package, as a quick way to move multiple files from one place to another, automatically (no drag and drop within Windows Explorer)

## What features will this version have?
I'm looking to re-create all functionality present in previous versions of QuickDeploy, only in a more polished format. This includes: 
- [ ] Ability to create deployments using the UI
- [ ] Ability to run deployments via the UI (obviously) 
- [ ] Build Counting utiliies baked right in, meaning you can track how many times you've run a particular deployment. (This feature, at present, is only available on my private version of the tools)

## New features
- Instead of serializing JSON/XML files for deployments, this time - I'm doing it using a database. 
  - There will be multiple database tables, one to hold the main deployment record, then multiple "child tables" (bound together using the main Deployment ID) which hold information such as file/folder records, and configuration.


## Contribution
I'm down to contribute on this project, and if you feel as if you can contribute to the functionality of the tools, please do fork and create a feature branch.

## Donation
If you use QuickDeploy, and find it useful - please feel more than welcome to [buy me a coffee](https://buymeacoffee.com/maxplayle) or [donate on PayPal](https://paypal.me/thatmaxplayle)
 
## Architecture
This application uses Windows Forms, due to the simplicity of the WinForms framework. This project will not be using any ultra-modern design spec, because
there's ultimately no use for it. 
