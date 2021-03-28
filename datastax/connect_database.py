from cassandra.cluster import Cluster
from cassandra.auth import PlainTextAuthProvider
import cassandra

#print(cassandra.*version*)
print("hi")
cloud_config= {
        'secure_connect_bundle': 'secure-connect-datastax-test.zip'
}
#read only user
auth_provider = PlainTextAuthProvider('jtgxXIeREYOHLmDTMxaqESnB', '9v6B0EPyhzAxe7PA8r,AiX_qpBly5XKOqZ7I4mePtJIY6c363XsD7cn,n4n14Zuutgh3N+pavPIdQ6Mqky4YyzHEsTWWsXZcnWxmPbrBde0+_bE2l0fU7t-1QskkTIeu')
cluster = Cluster(cloud=cloud_config, auth_provider=auth_provider)
session = cluster.connect()

row = session.execute("select * from datastax.people").all()
if row:
    print(row)
else:
    print("An error occurred.")
