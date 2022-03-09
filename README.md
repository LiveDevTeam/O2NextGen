# O2 NEXTGEN (Codename Citadel)

[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FLiveDevTeam%2FO2NextGen.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FLiveDevTeam%2FO2NextGen?ref=badge_shield)

#### Build & Coverage

| master coverage status | dev coverage status |
| ------------- | ------------- |
| [![Coverage Status](https://coveralls.io/repos/github/LiveDevTeam/O2NextGen/badge.svg?branch=master)](https://coveralls.io/github/LiveDevTeam/O2NextGen?branch=master) [![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FLiveDevTeam%2FO2NextGen.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2FLiveDevTeam%2FO2NextGen?ref=badge_shield)
| [![Coverage Status](https://coveralls.io/repos/github/LiveDevTeam/O2NextGen/badge.svg?branch=dev)](https://coveralls.io/github/LiveDevTeam/O2NextGen?branch=dev) |
| ------------- | ------------- |



| Service | build status | coverage status | dev - build status | dev - coverage status |
| ------------- | ------------- | ------------- | ------------- | ------------- |
| O2 Auth: | [![o2-auth](https://github.com/LiveDevTeam/O2NextGen/actions/workflows/o2-auth.yml/badge.svg?branch=master)](https://github.com/LiveDevTeam/O2NextGen/actions/workflows/o2-auth.yml) |                |[![o2-auth](https://github.com/LiveDevTeam/O2NextGen/actions/workflows/o2-auth.yml/badge.svg?branch=dev)](https://github.com/LiveDevTeam/O2NextGen/actions/workflows/o2-auth.yml) |                |
| C-Gen: |[![c-gen](https://github.com/LiveDevTeam/O2NextGen/actions/workflows/c-gen.yml/badge.svg?branch=master)](https://github.com/LiveDevTeam/O2NextGen/actions/workflows/c-gen.yml) |                | [![c-gen](https://github.com/LiveDevTeam/O2NextGen/actions/workflows/c-gen.yml/badge.svg?branch=dev)](https://github.com/LiveDevTeam/O2NextGen/actions/workflows/c-gen.yml) |                |
| S-Link: |                |                |                |                |
| L-Pay: |                |                |                |                |
| ------------- | ------------- |------------- | ------------- | ------------- |

Additionally:

[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=bugs)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=bugs)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=LiveDevTeam_O2NextGen&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=LiveDevTeam_O2NextGen)


#### Logo:

<img width="450" src="design/o2nextgen/logos/Screen Shot 2021-10-08 at 12.31.26 AM.png">




## Derivative products
* #PF_R Community ( Personal Functional Recovery Community)

<img width="450" src="design/pfr-app/logo/pfr-logo_ration16x9.png">

* SmallTalk
 

## Project started with
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
* `devops` Commits, that affect operational components like infrastructure, deployment, backup, recovery, ...
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
  
## MSSQL scripts conversion

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

#### Sample
* ```
    DDL - O2NextGen - dbo.Athlete_Group(dbo.[Table Name])
  ```
* ```
    DDL - O2NextGen - usp - json - Get_Config([dbo.usp_json_[Procedure Name]])
  ```
* ```
    DDL - O2NextGen - usp - Insert_Competition_Program([dbo.usp_[Procedure Name])
  ```
* ```
    DDL - O2NextGen - utf - Insert_Competition_Program([dbo.utf_[Function Name])
  ```
* ```
    DDL - O2NextGens_Tests - usp - Run_All_Tests(dbo.usp_[Procedure Name])
  ```


## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2FLiveDevTeam%2FO2NextGen.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2FLiveDevTeam%2FO2NextGen?ref=badge_large)


# Versions

#### Version information for an assembly consists of the following four values:

```
1.0.0.0
```

Description
```
major - Major Version
minor - Minor Version 
build number - Build Number 
              0 - alpha
                sample: 1.1.0.1 like (1.1-a.1)
              1 - beta
                sample: 1.1.1.2 like (1.1-b.2)
              2 - release candidate
                sample: 1.1.2.1 like (1.1-rc.1)
              3 - release
                sample: 1.1.3.3 like (1.1-r.3)
revision - git revision
  ```
  ```
