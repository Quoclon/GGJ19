"""
converts seconds to ms
"""

import csv
import sys
import re

def readCSV(path):
    csvData = []
    print('opening: ',path)
    with open(path) as csvFile:
        for row in csv.DictReader(csvFile):
            csvData.append(row)
    return csvData

def convertData(data):
    print("converting to ms...")
    for row in data:
        mins = re.search(r'\d+\:', row["TimeStamp"])
        sec = re.search(r'\d+\.', row["TimeStamp"])
        ms = row["TimeStamp"][-3:]

        sec_converted = int(sec.group(0)[:-1])*1000
        # print int(sec_converted)
        mins_converted = int(mins.group(0)[:-1])*1000*60
        total_ms = int(ms)+sec_converted+mins_converted
        row["TimeStamp"] = total_ms
    return data

def writeNewCSV(path, toWrite):
    print("writing: ",path[:-4]+"_converted.csv")
    with open(path[:-4]+"_converted.csv","wb") as csvFile:
        fieldNames = toWrite[0].keys()
        writer = csv.DictWriter(csvFile, fieldnames=fieldNames)
        writer.writeheader()
        for row in toWrite:
            writer.writerow(row)

def main():
    if(len(sys.argv)<2):
        print("supply a valid .csv path")
        return
    else:
        csvData = readCSV(sys.argv[1])
        converted = convertData(csvData)
        writeNewCSV(sys.argv[1],converted)


main()

