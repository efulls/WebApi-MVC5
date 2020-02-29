#Error: 'ReadAsAsync' accepting a first argument of type 'HttpContent' could be found
Solution: Right click on project and click Add a reference option, then go to Extensions from 
Assemblies tab and choose System.Net.Http.Formatting. If its not there then add 
manually this assembly, which is also available in the folder:
C:\Program Files\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies 