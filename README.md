TFS Code Comment Checking Policy (CCCP)
===========================

Documentation is available at the original [CodePlex project location](http://tfsccpolicy.codeplex.com/) 

The source code has been moved with the intention of easier contribution / adapting by others.

## Note for Setup

[Article: Deploy Custom Checkin Policy VS 2012](http://social.msdn.microsoft.com/Forums/vstudio/en-US/bfd4ede7-3b60-48a2-8344-a7b34e7d8d26/deploy-custom-checkin-policy-vs-2012)

Setup has to run `devenv /setup`, thus setup will take about a minute to finish (same on uninstall).

Suggested fix: add a .VSIX package instead of a classic setup (per-user install instead of per-machine)