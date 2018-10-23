#!/usr/bin/env python
# coding=utf-8
# title           : manipulator.py
# description     : Aux code for assignment one
# author          : Thecave3
# date            : 02/10/2018
# version         : 0.1
# usage           : python manipulator.py
# notes           : needs a data.csv file in the same folder
# python_version  : 3.1
# ==============================================================================

data = open('Student_Survey_Dataset.csv')

# Sesso,Age,Weight (kg),Height (cm),Background,Hobby,Main Interest,Trasportation,Main Informatic Interest

lst = []

# Estrazione dati e creazione lista
for i in data:
    lst.append(i.strip('\n').split(','))  # inserisco ogni riga dentro la lst
    # print(lst)

# Analisi frequenza SESSO

num_maschi = 0
num_femmin = 0
for j in lst:
    if j[0] == 'M':
        num_maschi += 1
    else:
        num_femmin += 1

print("Numero maschi: " + str(num_maschi) + " , Numero femmine: " + str(num_femmin))

print("Frequenza maschi: " + str(num_maschi / (num_femmin + num_maschi)) + " , Frequenza femmine: " + str(
    num_femmin / (num_femmin + num_maschi)))

# Analisi frequenza Età
total = 0
for j in lst:
    total += int(j[1])

print("Media età: " + str(total / len(lst)))

etats = {}
for j in lst:
    if j[1] in etats:
        etats[j[1]] = etats[j[1]] + 1
    else:
        etats[j[1]] = 1

print("Frequenza valori età { età : numero }: " + str(etats))

# Analisi frequenza di trasporti | età = 23

trasp_over_age = {}

for j in lst:
    if j[1] == '23':
        if j[7] in trasp_over_age:
            trasp_over_age[j[7]] = trasp_over_age[j[7]] + 1
        else:
            trasp_over_age[j[7]] = 1

print("Frequenza valori trasporti | età = 23 , { tipo trasporto : numero }: " + str(trasp_over_age))


# Assignment 2


class Studente:
    def __init__(self, sesso, eta, peso, altezza, background, hobby, interest, transport, informatic):
        self.sesso = sesso
        self.eta = eta
        self.peso = peso
        self.altezza = altezza
        self.background = background
        self.hobby = hobby
        self.interest = interest
        self.transport = transport
        self.informatic = informatic

    def __str__(self) -> str:
        return "[" + self.sesso + "," + self.eta + "," + self.altezza + "," + self.background + "," + self.hobby + "," + self.interest + "," + self.transport + "," + self.informatic + "]"


students = []

for j in lst:
    students.append(Studente(j[0], j[1], j[2], j[3], j[4], j[5], j[6], j[7], j[8]))

for i in students:
    print(i)
