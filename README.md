# O2 NEXTGEN (Codename Citadel)
<img src="design/o2nextgen/logos/Screen Shot 2021-10-08 at 12.31.26 AM.png">

### Derivative products
#PF_R Community ( Personal Functional Recovery Community)
<img src="design/pfr-app/logo/pfr-logo_ration16x9.png">

#### Deployment


# Project started with
Used .net version .NET Core 2.1( 2.1.818);
Url for download https://dotnet.microsoft.com/download/dotnet/2.1

{% page-ref page="deploy/local-machine/" %}

{% page-ref page="deploy/clouds/" %}


## Commit Formats
#### Types
* API relevant changes
    * `feat` Commits, that adds a new feature
    * `fix` Commits, that fixes a bug
* `refactor` Commits, that rewrite/restructure your code, however does not change any behaviour
    * `perf` Commits are special `refactor` commits, that improves performance
* `style` Commits, that do not affect the meaning (white-space, formatting, missing semi-colons, etc)
* `test` Commits, that add missing tests or correcting existing tests
* `docs` Commits, that affect documentation only
* `build` Commits, that affect build components like build tool, ci pipeline, dependencies, project version, ...
* `ops` Commits, that affect operational components like infrastructure, deployment, backup, recovery, ...
* `chore` Miscellaneous commits e.g. modifying `.gitignore`

#### Subject
* use imperative, present tense (eg: use "add" instead of "added" or "adds")
* don't use dot(.) at end
* don't capitalize first letter

### Examples
* ```
  feat(c-get service): add the amazing button
  ```
* ```
  feat: remove ticket list endpoint
  
  refers to JIRA-12337
  BREAKING CHANGES: ticket enpoints no longer supports list all entites.
  ```
* ```
  fix: add missing parameter to service call
  
  The error occurred because of <reasons>.
  ```
* ```
  build(release): bump version to 1.0.0
  ```
* ```
  build: update dependencies
  ```
* ```
  refactor: implement calculation method as recursion
  ```
* ```
  style: remove empty line
  ```
  
### MSSQL scripts conversion

#### Abbreviated names 

* ```
  uc - User Constraint
  ```
* ```
  usp - User Stored Procedure
  ```
* ```
  utf - User Functions
  ```

#### Database
* Example PK :  
```  
Table name - 'Test_Table'
```
``` 
PK name - 'PK_TestTable'
```

* Example FK :  
```
Table name - 'Test_Table'
``` 
```
Reference table name - 'Ref_Test_Table'
``` 
```
FK name - 'FK_TestTable_RefTestTable'
``` 

* Example DF :  
```
Table name - 'Test_Table'
``` 
```
Columns name for DF - 'column_name'
``` 
```
DF name - 'DF_columnName'
``` 

* Example AK :  
```
Table name - 'Test_Table'
``` 
```
Columns name for AK - 'column_name', 'column_name_id'
``` 
```
AK name - 'AK_columnName_columnNameId'
``` 

 
#### Type script 

#### Names of script

* ```
  DDL
  ```
* ```
  DML
  ```