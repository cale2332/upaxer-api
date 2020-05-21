select * from tpa.DatosGenerales where id='89C420AD-373E-4D4E-B866-025E1495B5EC'
select * from cont.RazonSocial
select * from cont.PersonaFisica
select * from cont.PersonaMoral

select dt.id, rz.id, pf.id from tpa.DatosGenerales dt 
inner join cont.RazonSocial rz on dt.idRazonSocial = rz.id
inner join cont.PersonaFisica pf on rz.id = pf.idRazonSocial 

select dt.id, rz.id, pm.id from tpa.DatosGenerales dt 
inner join cont.RazonSocial rz on dt.idRazonSocial = rz.id
inner join cont.PersonaMoral pm on rz.id = pm.idRazonSocial 

select * from cat.Mail
select * from tpa.Oficinas
select * from cont.Notaria where id = '4cf62754-8ddb-48d8-a69a-63be66c5cf92';

select * from rel.Oficina_Contactojlk

select * from cat.nacionalidad where id= '6d13fa0a-3406-4000-b07e-9a633ff5a87e'
--Delete from rel.RazonSocial_TipoFiscal Where idRazonSocial = CONVERT(uniqueidentifier, '89c420ad-373e-4d4e-b866-025e1495b5ec')
select * from cat.Direccion where id in('6AE85950-58DD-4B20-8E19-07EEBC677273',
'935CACD9-42E6-4B0C-AA18-E71B38AC1B59')

sp_help 'cat.telefono'
select LEN('TTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGUUUUUUUUUUUUUUU90')




CREATE SCHEMA [Security]
    AUTHORIZATION [dbo];

	CREATE TABLE [Security].[Roles] (
    [Id]          TINYINT      NOT NULL,
    [Description] VARCHAR (50) NULL,
    [Active]      BIT          DEFAULT ((1)) NULL,
    [CreatedDate] DATETIME     DEFAULT (getdate()) NULL,
    [CreatedBy]   VARCHAR (50) NULL,
    [UpdatedDate] DATETIME     NULL,
    [UpdatedBy]   VARCHAR (50) NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [Security].[Users] (
    [Id]          NVARCHAR (128) NOT NULL,
    [UserName]    VARCHAR (255)  NOT NULL,
    [Password]    VARCHAR (255)  NOT NULL,
    [RoleId]      TINYINT        NOT NULL,
    [Active]      BIT            DEFAULT ((1)) NULL,
    [CreatedDate] DATETIME       DEFAULT (getdate()) NULL,
    [CreatedBy]   VARCHAR (50)   NULL,
    [UpdatedDate] DATETIME       NULL,
    [UpdatedBy]   VARCHAR (50)   NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Security].[Roles] ([Id])
);
CREATE TABLE [Security].[RolesClaims] (
    [Id]          NVARCHAR (128) NOT NULL,
    [RoleId]      TINYINT        NOT NULL,
    [ClaimType]   VARCHAR (100)  NOT NULL,
    [ClaimValue]  VARCHAR (50)   NOT NULL,
    [Active]      BIT            DEFAULT ((1)) NULL,
    [CreatedDate] DATETIME       DEFAULT (getdate()) NULL,
    [CreatedBy]   VARCHAR (50)   NULL,
    [UpdatedDate] DATETIME       NULL,
    [UpdatedBy]   VARCHAR (50)   NULL,
    CONSTRAINT [PK_RolesClaims] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_RolesClaim_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Security].[Roles] ([Id])
);