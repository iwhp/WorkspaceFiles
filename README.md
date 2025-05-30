[marketplace]: https://marketplace.visualstudio.com/items?itemName=MadsKristensen.WorkflowBrowser
[vsixgallery]: http://vsixgallery.com/extension/WorkspaceFiles.e5308ac4-ca47-4992-945b-9b144a10c2d0/
[repo]:https://github.com/madskristensen/WorkspaceFiles

# File Explorer for Visual Studio

[![Build](https://github.com/madskristensen/WorkspaceFiles/actions/workflows/build.yaml/badge.svg)](https://github.com/madskristensen/WorkspaceFiles/actions/workflows/build.yaml)

Download this extension from the [Visual Studio Marketplace][marketplace]
or get the [CI build][vsixgallery].

----------------------------------------

> Inspired by [a popular Visual Studio feature request](https://developercommunity.visualstudio.com/t/Make-Solution-Folders-map-to-real-folder/358125?ftype=idea&stateGroup=active) on Developer Community.

Gives access to all files and folders from the file system under the repo- or solution root folder, all within the Solution Explorer view.

![Animation](art/animation.gif)

Add any folder by right-clicking the solution node and selecting **Add > Existing Folder**.

![Add Physical Folder](art/add-physical-folder.png)

## .gitignore support

Files and folders matching a pattern in the `.gitignore` file are automatically grayed out in the Solution Explorer.

## Image hover preview

**Hovering over image files** shows a preview tooltip of the image.

## Filters

You can filter the files and folders shown by going to **Tools > Options > File Explorer** and setting the filters there.

## How can I help?
If you enjoy using the extension, please give it a ★★★★★ rating on the [Visual Studio Marketplace][marketplace]. It only takes a few seconds but makes a huge difference!

Found a bug or have a feature idea? Head over to the [GitHub repo][repo] to open an issue if one doesn't already exist.

Pull requests are enthusiastically welcomed! As this is a personal passion project maintained in my spare time, I can't always address every issue promptly. Your contributions help keep this extension vibrant and reliable for everyone.

If you find this extension saves you time or improves your workflow, please consider [sponsoring me on GitHub](https://github.com/sponsors/madskristensen). Even a small donation helps ensure continued development and support. Your sponsorship directly enables me to dedicate more time to this and other free extensions for the community. Thank you for your support!