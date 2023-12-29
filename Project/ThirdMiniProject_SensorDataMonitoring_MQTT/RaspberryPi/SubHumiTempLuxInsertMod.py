
from influxdb import InfluxDBClient	#file name : SubHumiTempInsetMod.py
import paho.mqtt.client as mqtt
dbClient = InfluxDBClient(host='192.168.2.35', port=8086, username='influx_woo', password='1234',
		database='db_riatech')
def on_connect( client, userdata, flags, rc ):
   print("Connect with result code " + str(rc) )
   client.subscribe("Sensors/MyOffice/#")


def on_message( client, userdata, msg ):
   print( msg.topic + " " +str(msg.payload) )
   # msg.topic 🡪 ‘Sensors/MyOffice/Indoor/SensorValue’
   topic = msg.topic.split('/')
   loc = topic[1]
   subloc = topic[2]
   # msg.payload 🡪 “{‘Temp’ : 23.1, ‘Humi’: 33.3}”
   payload = eval(msg.payload)

   json_body = [ ]
   data_point = {
	'measurement': 'Sensors',
	'tags': {'Location': ' ', 'SubLocation':' '},
	'fields': {'Temp': 0.0, 'Humi':0.0, 'Lux' : 0.0}
	}
   data_point['tags']['Location'] = loc
   data_point['tags']['SubLocation'] = subloc
   data_point['fields']['Temp'] = payload['Temp']
   data_point['fields']['Humi'] = payload['Humi']
   data_point['fields']['Lux'] = payload['Lux']
   json_body.append(data_point)
   dbClient.write_points( json_body )

client = mqtt.Client( )
client.username_pw_set(username="mqtt_riatech", password="1234")
client.on_connect = on_connect
client.on_message = on_message
client.connect("192.168.2.35", 1883, 60)
client.loop_forever( )

