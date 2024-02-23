Zadatak za Wiener osiguranje. 
Uputa za pokretanje: skinuti kod, buildati i pokrenuti u Visual Studiu.

Opis baze podataka: 
  
Tablica Partners:
  PartnerId(PK,int,not null)
  FirstName(nvarchar, not null)
  LastName(nvarchar, not null)
  Address(nvarchar, null)
  CroatianPIN(varchar, null)
  CreatedAtUtc(datetime,not null)
  CreateByUser(nvarchar, not null)
  IsForeign(bool, not null)
  ExternalCode(nvarchar, null)
  Gender(char, not null)
  PartnerNumber(varchar, not null)
  PartnerTypeId(int, not null)

Tablica Policies: 
  PolicyId(PK,int,not null)
  PartnerId(FK, int, null)
  PolicyAmount(decimal, not null) 
