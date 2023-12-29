client = InfluxDBClient(host = 'localhost', port=8086, username='Influx_woo', database='db_riatech')
json_body = 
	“measurement” : “temperature”,
	“tags” : { “Location” : “Indoor”},  
                  “fields” : {‘Temp’: 0.0 }
	} 
]
client.write_points(json_body)

