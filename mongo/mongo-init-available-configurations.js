const initialAvailableConfigurations = [
    {
        "Brand": {
            "Code": "BC01",
            "Name": "Sii"
        },
        "Model": {
            "Code": "MC03",
            "Name": "Model L"
        },
        "EquipmentVersion": {
            "Code": "EV03",
            "Name": "Premium"
        },
        "Class": {
            "Code": "CC03",
            "Name": "Midsize"
        },
        "Engine": {
            "Code": "EC03",
            "Name": "1.4 TSI",
            "Type": "Petrol",
            "Capacity": 1399,
            "Power": 125
        },
        "Gearbox": {
            "Code": "GC03",
            "Type": "automatic",
            "GearsCount": 6
        },
        "Color": {
            "Code": "CO03",
            "Name": "red"
        },
        "Interior": {
            "Code": "IC03",
            "Name": "dark"
        },
        "AdditionalEquipment": [
            {
                "Code": "AE01",
                "Name": "comfort seat package"
            }
        ],
        "Price": 125000
    },
    {
        "Brand": {
            "Code": "BC01",
            "Name": "Sii"
        },
        "Model": {
            "Code": "MC02",
            "Name": "Model M"
        },
        "EquipmentVersion": {
            "Code": "EV02",
            "Name": "Comfort"
        },
        "Class": {
            "Code": "CC02",
            "Name": "Compact"
        },
        "Engine": {
            "Code": "EC02",
            "Name": "1.2 TSI",
            "Type": "Petrol",
            "Capacity": 1198,
            "Power": 110
        },
        "Gearbox": {
            "Code": "GC02",
            "Type": "manual",
            "GearsCount": 6
        },
        "Color": {
            "Code": "CO02",
            "Name": "white"
        },
        "Interior": {
            "Code": "IC02",
            "Name": "light leather"
        },
        "AdditionalEquipment": [
            {
                "Code": "AE01",
                "Name": "comfort seat package"
            },
            {
                "Code": "AE02",
                "Name": "sport package"
            }
        ],
        "Price": 120000
    },
    {
        "Brand": {
            "Code": "BC01",
            "Name": "Sii"
        },
        "Model": {
            "Code": "MC01",
            "Name": "Model S"
        },
        "EquipmentVersion": {
            "Code": "EV01",
            "Name": "Basic"
        },
        "Class": {
            "Code": "CC01",
            "Name": "City"
        },
        "Engine": {
            "Code": "EC01",
            "Name": "1.0 TSI",
            "Type": "Petrol",
            "Capacity": 998,
            "Power": 75
        },
        "Gearbox": {
            "Code": "GC01",
            "Type": "manual",
            "GearsCount": 5
        },
        "Color": {
            "Code": "CO01",
            "Name": "black"
        },
        "Interior": {
            "Code": "IC01",
            "Name": "black leather"
        },
        "AdditionalEquipment": [
            {
                "Code": "AE01",
                "Name": "comfort seat package"
            },
            {
                "Code": "AE02",
                "Name": "sport package"
            }
        ],
        "Price": 100000
    },
    {
        "Brand": {
            "Code": "BC01",
            "Name": "Sii"
        },
        "Model": {
            "Code": "MC04",
            "Name": "Model L"
        },
        "EquipmentVersion": {
            "Code": "EV04",
            "Name": "Exclusive"
        },
        "Class": {
            "Code": "CC04",
            "Name": "Fullsize"
        },
        "Engine": {
            "Code": "EC04",
            "Name": "2.0 TSI",
            "Type": "Petrol",
            "Capacity": 1998,
            "Power": 211
        },
        "Gearbox": {
            "Code": "GC04",
            "Type": "automatic",
            "GearsCount": 7
        },
        "Color": {
            "Code": "CO04",
            "Name": "blue"
        },
        "Interior": {
            "Code": "IC04",
            "Name": "light"
        },
        "AdditionalEquipment": [
            {
                "Code": "AE01",
                "Name": "comfort seat package"
            },
            {
                "Code": "AE02",
                "Name": "sport package"
            },
            {
                "Code": "AE03",
                "Name": "family package"
            },
            {
                "Code": "AE04",
                "Name": "assisted drive package"
            },
            {
                "Code": "AE05",
                "Name": "safety package"
            },
            {
                "Code": "AE06",
                "Name": "exclusive sound system"
            }
        ],
        "Price": 145000
    },
    {
        "Brand": {
            "Code": "BC01",
            "Name": "Sii"
        },
        "Model": {
            "Code": "MC05",
            "Name": "Model Y"
        },
        "EquipmentVersion": {
            "Code": "EV05",
            "Name": "Luxury"
        },
        "Class": {
            "Code": "CC05",
            "Name": "SUV"
        },
        "Engine": {
            "Code": "EC05",
            "Name": "2.0 TSI",
            "Type": "Petrol",
            "Capacity": 1998,
            "Power": 300
        },
        "Gearbox": {
            "Code": "GC04",
            "Type": "automatic",
            "GearsCount": 7
        },
        "Color": {
            "Code": "CO05",
            "Name": "grey"
        },
        "Interior": {
            "Code": "IC05",
            "Name": "beige"
        },
        "AdditionalEquipment": [
            {
                "Code": "AE01",
                "Name": "comfort seat package"
            },
            {
                "Code": "AE02",
                "Name": "sport package"
            },
            {
                "Code": "AE03",
                "Name": "family package"
            },
            {
                "Code": "AE04",
                "Name": "assisted drive package"
            },
            {
                "Code": "AE05",
                "Name": "safety package"
            },
            {
                "Code": "AE06",
                "Name": "exclusive sound system"
            }
        ],
        "Price": 155000
    },
    {
        "Brand": {
            "Code": "BC01",
            "Name": "Sii"
        },
        "Model": {
            "Code": "MC06",
            "Name": "Model T"
        },
        "EquipmentVersion": {
            "Code": "EV05",
            "Name": "Luxury"
        },
        "Class": {
            "Code": "CC06",
            "Name": "GT"
        },
        "Engine": {
            "Code": "EC06",
            "Name": "4.0 V8 TFSI",
            "Type": "Petrol",
            "Capacity": 3989,
            "Power": 650
        },
        "Gearbox": {
            "Code": "GC04",
            "Type": "automatic",
            "GearsCount": 7
        },
        "Color": {
            "Code": "CO06",
            "Name": "green"
        },
        "Interior": {
            "Code": "IC06",
            "Name": "grey"
        },
        "AdditionalEquipment": [
            {
                "Code": "AE01",
                "Name": "comfort seat package"
            },
            {
                "Code": "AE02",
                "Name": "sport package"
            },
            {
                "Code": "AE03",
                "Name": "family package"
            },
            {
                "Code": "AE04",
                "Name": "assisted drive package"
            },
            {
                "Code": "AE05",
                "Name": "safety package"
            },
            {
                "Code": "AE06",
                "Name": "exclusive sound system"
            }
        ],
        "Price": 199000
    },
    {
        "Brand": {
            "Code": "BC01",
            "Name": "Sii"
        },
        "Model": {
            "Code": "MC02",
            "Name": "Model M"
        },
        "EquipmentVersion": {
            "Code": "EV01",
            "Name": "Basic"
        },
        "Class": {
            "Code": "CC01",
            "Name": "City"
        },
        "Engine": {
            "Code": "EC07",
            "Name": "1.4 TDI",
            "Type": "Diesel",
            "Capacity": 1388,
            "Power": 90
        },
        "Gearbox": {
            "Code": "GC01",
            "Type": "manual",
            "GearsCount": 5
        },
        "Color": {
            "Code": "CO07",
            "Name": "yellow"
        },
        "Interior": {
            "Code": "IC04",
            "Name": "light"
        },
        "AdditionalEquipment": [
            {
                "Code": "AE01",
                "Name": "comfort seat package"
            }
        ],
        "Price": 90000
    },
    {
        "Brand": {
            "Code": "BC01",
            "Name": "Sii"
        },
        "Model": {
            "Code": "MC02",
            "Name": "Model M"
        },
        "EquipmentVersion": {
            "Code": "EV02",
            "Name": "Comfort"
        },
        "Class": {
            "Code": "CC01",
            "Name": "Compact"
        },
        "Engine": {
            "Code": "EC08",
            "Name": "1.6 TDI",
            "Type": "Diesel",
            "Capacity": 1599,
            "Power": 110
        },
        "Gearbox": {
            "Code": "GC02",
            "Type": "manual",
            "GearsCount": 6
        },
        "Color": {
            "Code": "CO08",
            "Name": "silver"
        },
        "Interior": {
            "Code": "IC06",
            "Name": "grey"
        },
        "AdditionalEquipment": [
            {
                "Code": "AE01",
                "Name": "comfort seat package"
            }
        ],
        "Price": 1000000
    },
    {
        "Brand": {
            "Code": "BC01",
            "Name": "Sii"
        },
        "Model": {
            "Code": "MC09",
            "Name": "KODIAQ RS"
        },
        "EquipmentVersion": {
            "Code": "EV02",
            "Name": "Premium"
        },
        "Class": {
            "Code": "CC01",
            "Name": "Compact"
        },
        "Engine": {
            "Code": "EC08",
            "Name": "2.0 TDI SCR 4x4",
            "Type": "Diesel",
            "Capacity": 1998,
            "Power": 200
        },
        "Gearbox": {
            "Code": "GC02",
            "Type": "automatic",
            "GearsCount": 7
        },
        "Color": {
            "Code": "CO04",
            "Name": "blue"
        },
        "Interior": {
            "Code": "IC06",
            "Name": "grey"
        },
        "AdditionalEquipment": [
            {
                "Code": "AE01",
                "Name": "comfort seat package"
            }
        ],
        "Price": 210600
    }
]
console.log(initialAvailableConfigurations);
db.AvailableConfigurations.insertMany(initialAvailableConfigurations);
