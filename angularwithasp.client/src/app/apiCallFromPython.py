import requests

url = "https://localhost:55350/api/python/GetInfo"
response = requests.get(url, verify=False)

if response.status_code == 200:
    print("Response from .NET Core API:", response.json())
else:
    print("Error:", response.status_code)
