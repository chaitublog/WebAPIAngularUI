CREATE TABLE [dbo].[Customer](

                [CustID] [int] IDENTITY(1,1) NOT NULL,

                [CustFirstName] [varchar](255) NOT NULL,

                [CustLastName] [varchar](255) NOT NULL,

                [CustContactNum] [varchar](255) NULL,

                [CustAddress] [varchar](255) NULL,

                [CustCountry] [varchar](255) NULL,

                [CustRegisterData] [date] NULL,

PRIMARY KEY CLUSTERED

(

                [CustID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]

 

CREATE TABLE [dbo].[UserLogin](

                [UID] [int] IDENTITY(1,1) NOT NULL,

                [Username] [varchar](50) NOT NULL,

                [Password] [varchar](50) NOT NULL,

                [Role] [varchar](50) NOT NULL,

                [Token] [varchar](1) NULL,

PRIMARY KEY CLUSTERED

(

                [UID] ASC

)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

) ON [PRIMARY]