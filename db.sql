/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     29/04/2021 17:21:36                          */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('FoodPairing') and o.name = 'FK_FOODPAIR_REFERENCE_BEER')
alter table FoodPairing
   drop constraint FK_FOODPAIR_REFERENCE_BEER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Ingredient') and o.name = 'FK_INGREDIE_REFERENCE_INGREDIE')
alter table Ingredient
   drop constraint FK_INGREDIE_REFERENCE_INGREDIE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Ingredient') and o.name = 'FK_INGREDIE_REFERENCE_BEER')
alter table Ingredient
   drop constraint FK_INGREDIE_REFERENCE_BEER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Method') and o.name = 'FK_METHOD_REFERENCE_METHODTY')
alter table Method
   drop constraint FK_METHOD_REFERENCE_METHODTY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Method') and o.name = 'FK_METHOD_REFERENCE_BEER')
alter table Method
   drop constraint FK_METHOD_REFERENCE_BEER
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Volume') and o.name = 'FK_VOLUME_REFERENCE_VOLUMETY')
alter table Volume
   drop constraint FK_VOLUME_REFERENCE_VOLUMETY
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Volume') and o.name = 'FK_VOLUME_REFERENCE_BEER')
alter table Volume
   drop constraint FK_VOLUME_REFERENCE_BEER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AmountUnit')
            and   type = 'U')
   drop table AmountUnit
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Beer')
            and   name  = 'Idx_BeerId'
            and   indid > 0
            and   indid < 255)
   drop index Beer.Idx_BeerId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Beer')
            and   type = 'U')
   drop table Beer
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('FoodPairing')
            and   name  = 'Idx_FoodPairingId'
            and   indid > 0
            and   indid < 255)
   drop index FoodPairing.Idx_FoodPairingId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FoodPairing')
            and   type = 'U')
   drop table FoodPairing
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Ingredient')
            and   name  = 'Idx_IngredientId'
            and   indid > 0
            and   indid < 255)
   drop index Ingredient.Idx_IngredientId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Ingredient')
            and   type = 'U')
   drop table Ingredient
go

if exists (select 1
            from  sysobjects
           where  id = object_id('IngredientType')
            and   type = 'U')
   drop table IngredientType
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Method')
            and   name  = 'Idx_MethodId'
            and   indid > 0
            and   indid < 255)
   drop index Method.Idx_MethodId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Method')
            and   type = 'U')
   drop table Method
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MethodType')
            and   type = 'U')
   drop table MethodType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TemperatureUnit')
            and   type = 'U')
   drop table TemperatureUnit
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Volume')
            and   name  = 'Idx_VolumeId'
            and   indid > 0
            and   indid < 255)
   drop index Volume.Idx_VolumeId
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Volume')
            and   type = 'U')
   drop table Volume
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VolumeType')
            and   type = 'U')
   drop table VolumeType
go

if exists (select 1
            from  sysobjects
           where  id = object_id('VolumeUnit')
            and   type = 'U')
   drop table VolumeUnit
go

/*==============================================================*/
/* Table: AmountUnit                                            */
/*==============================================================*/
create table AmountUnit (
   AmountUnitId         int                  not null,
   Name                 varchar(10)          not null,
   constraint PK_AMOUNTUNIT primary key (AmountUnitId),
   constraint Amount_Unit_Rule check (Name in('kilograms', 'grams', 'pounds', 'ounces'))
)
go

/*==============================================================*/
/* Table: Beer                                                  */
/*==============================================================*/
create table Beer (
   BeerId               int                  identity,
   Name                 varchar(255)         not null,
   Tagline              varchar(255)         null,
   First_Brewed         varchar(7)           null,
   Description          varchar(500)         null,
   Image_Url            varchar(255)         null,
   Abv                  numeric(2,1)         null,
   Ibu                  numeric(2,1)         null,
   Target_Fg            int                  null,
   Target_Og            int                  null,
   Ebc                  int                  null,
   Srm                  int                  null,
   Ph                   numeric(2,1)         null,
   Attenuation_Level    int                  null,
   Brewer_Tips          varchar(500)         null,
   Contributed_By       varchar(255)         null,
   constraint PK_BEER primary key (BeerId)
)
go

/*==============================================================*/
/* Index: Idx_BeerId                                            */
/*==============================================================*/
create index Idx_BeerId on Beer (
BeerId ASC
)
go

/*==============================================================*/
/* Table: FoodPairing                                           */
/*==============================================================*/
create table FoodPairing (
   FoodPairingId        int                  not null,
   BeerId               int                  null,
   Food                 varchar(255)         not null,
   constraint PK_FOODPAIRING primary key (FoodPairingId)
)
go

/*==============================================================*/
/* Index: Idx_FoodPairingId                                     */
/*==============================================================*/
create index Idx_FoodPairingId on FoodPairing (
FoodPairingId ASC
)
go

/*==============================================================*/
/* Table: Ingredient                                            */
/*==============================================================*/
create table Ingredient (
   IngredientId         int                  identity,
   IngredienteTypeId    int                  not null,
   BeerId               int                  not null,
   Name                 varchar(100)         not null,
   AmountUnit           varchar(20)          null,
   AmountValue          numeric(2,1)         null,
   "Add"                varchar(15)          null,
   Attribute            varchar(50)          null,
   constraint PK_INGREDIENT primary key (IngredientId)
)
go

/*==============================================================*/
/* Index: Idx_IngredientId                                      */
/*==============================================================*/
create index Idx_IngredientId on Ingredient (
IngredientId ASC
)
go

/*==============================================================*/
/* Table: IngredientType                                        */
/*==============================================================*/
create table IngredientType (
   IngredienteTypeId    int                  not null,
   Name                 varchar(100)         not null,
   constraint PK_INGREDIENTTYPE primary key (IngredienteTypeId)
)
go

/*==============================================================*/
/* Table: Method                                                */
/*==============================================================*/
create table Method (
   MethodId             int                  identity,
   MethodTypeId         int                  not null,
   BeerId               int                  not null,
   TemperatureUnit      varchar(20)          null,
   TemperatureValue     int                  null,
   Duration             int                  null,
   constraint PK_METHOD primary key (MethodId)
)
go

/*==============================================================*/
/* Index: Idx_MethodId                                          */
/*==============================================================*/
create index Idx_MethodId on Method (
MethodId ASC
)
go

/*==============================================================*/
/* Table: MethodType                                            */
/*==============================================================*/
create table MethodType (
   MethodTypeId         int                  not null,
   Name                 varchar(255)         not null,
   constraint PK_METHODTYPE primary key (MethodTypeId)
)
go

/*==============================================================*/
/* Table: TemperatureUnit                                       */
/*==============================================================*/
create table TemperatureUnit (
   IdTemperatureUnit    int                  not null,
   Name                 varchar(20)          null,
   constraint PK_TEMPERATUREUNIT primary key (IdTemperatureUnit),
   constraint Temperature_Unit_Rule check (Name in('celsius', 'fahrenheit '))
)
go

/*==============================================================*/
/* Table: Volume                                                */
/*==============================================================*/
create table Volume (
   VolumeId             int                  not null,
   VolumeTypeId         int                  not null,
   BeerId               int                  not null,
   VolumeUnit           varchar(20)          null,
   VolumeValue          int                  null,
   constraint PK_VOLUME primary key (VolumeId)
)
go

/*==============================================================*/
/* Index: Idx_VolumeId                                          */
/*==============================================================*/
create index Idx_VolumeId on Volume (
VolumeId ASC
)
go

/*==============================================================*/
/* Table: VolumeType                                            */
/*==============================================================*/
create table VolumeType (
   VolumeTypeId         int                  not null,
   Name                 varchar(255)         null,
   constraint PK_VOLUMETYPE primary key (VolumeTypeId)
)
go

/*==============================================================*/
/* Table: VolumeUnit                                            */
/*==============================================================*/
create table VolumeUnit (
   VolumeUnitId         int                  not null,
   Name                 varchar(15)          not null,
   constraint PK_VOLUMEUNIT primary key (VolumeUnitId),
   constraint Volume_Unit_Rule check (Name in ('litres', 'galons'))
)
go

alter table FoodPairing
   add constraint FK_FOODPAIR_REFERENCE_BEER foreign key (BeerId)
      references Beer (BeerId)
go

alter table Ingredient
   add constraint FK_INGREDIE_REFERENCE_INGREDIE foreign key (IngredienteTypeId)
      references IngredientType (IngredienteTypeId)
go

alter table Ingredient
   add constraint FK_INGREDIE_REFERENCE_BEER foreign key (BeerId)
      references Beer (BeerId)
         on delete cascade
go

alter table Method
   add constraint FK_METHOD_REFERENCE_METHODTY foreign key (MethodTypeId)
      references MethodType (MethodTypeId)
go

alter table Method
   add constraint FK_METHOD_REFERENCE_BEER foreign key (BeerId)
      references Beer (BeerId)
go

alter table Volume
   add constraint FK_VOLUME_REFERENCE_VOLUMETY foreign key (VolumeTypeId)
      references VolumeType (VolumeTypeId)
go

alter table Volume
   add constraint FK_VOLUME_REFERENCE_BEER foreign key (BeerId)
      references Beer (BeerId)
go

