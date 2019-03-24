import random

file = open("insertMM.sql","w+")

NUMBER_OF_KNIGHTS = 848
NUMBER_OF_MISSIONS = 566

line = "use JediLibraryDB;\n"
file.write(line)

line = "insert into MissionMembership \nvalues \n"
file.write(line)

for i in range(1,NUMBER_OF_MISSIONS+1):
    for j in range(1,random.randrange(1,5)):
        line = "('" + str(i) + "','" +  str(random.randrange(1, NUMBER_OF_KNIGHTS)) + "'),\n"
        file.write(line)

