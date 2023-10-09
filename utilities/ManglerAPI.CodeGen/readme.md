# ManglerAPI.CodeGen

This project doesn't do much, just moves swagger files around and makes backups.  If you 
run it on its own, the process won't work.  It should be invoked from `codeGen.sh`.  Eventually,
this logic will all be moved to the shell script.

## First time setup

1. Open a terminal into the project root where the shell scripts reside
2. Run `sudo chmod 755 "codeGen.sh"` and type password

## Steps to generate client code

1. Make changes to API
2. Make sure code is in a buildable state
3. Run `codeGen.sh`
4. ManglerAPI.Client will be rebuilt with new changes.  You may have to close any open tabs in Rider for it to pick them up.

## Steps to restore a backup swagger file

There isn't really a great reason to do this.  The better way would be fixing the api to generate
a proper swagger file.  But if for some reason you do, take the backup swagger file out of `backups` 
and copy it into the ManglerAPI.Client project, and rename it `manglerapi-openapi-spec.json`.  
Then build the client normally. 