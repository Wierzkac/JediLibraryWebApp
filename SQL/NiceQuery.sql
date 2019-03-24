select M.YearOfDone, M.Title, K.Name, K.ClassOfJediOrder, P.Name, P.Sector from Missions M, Knights K, MissionMembership MM,  Planets P, PlaceOfMission POM
where M.MissionID = MM.MissionID and K.KnightID = MM.KnightID and POM.PlanetID = P.PlanetID and M.MissionID = POM.MissionID
order by M.MissionID 
