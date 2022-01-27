# BeckhoffJsonReadWriter

[![Build status](https://ci.appveyor.com/api/projects/status/kn6dww5nf5r0patw?svg=true)](https://ci.appveyor.com/project/fbarresi/beckhoffjsonreadwriter)
![Licence](https://img.shields.io/github/license/fbarresi/BeckhoffJsonReadWriter.svg)
![GitHub All Releases](https://img.shields.io/github/downloads/fbarresi/BeckhoffJsonReadWriter/total)

Read and write json file from a Beckhoff PLC

This is an opensource library that allows read and write json files for Beckhoff PLCs.

## Key features

- **NO Licence** costs (This software is free also for commercial uses)
- supports the newest Json standard
- reads any Json body with complex nested structures (it also works with json lists of object as API response)
- parse any Json response to plc structure

## Prepare your PLC

- Install the _unofficial_ TwinCAT Function [TFU003](https://github.com/fbarresi/BeckhoffJsonReadWriter/releases/latest) on your target system
- Install the TwinCAT Library to your project

## How to use the TwinCAT Library

### Reference the BeckhoffJsonReadWriter Library

Download and reference the [BeckhoffJsonReadWriter library](https://github.com/fbarresi/BeckhoffJsonReadWriter/releases/latest) and import it to your project.

![](https://github.com/fbarresi/BeckhoffJsonReadWriter/raw/master/docs/library.png)

You can now declare and call a json parser in your program and start using json files.

```
PROGRAM MAIN
VAR
	parser : JsonParser;
END_VAR
```
```
parser(
	Execute:=FALSE , 
	File:= 'C:\temp\my-fancy-json.json', 
	ParseMethod:= 'ReadFile' , // or even 'WriteFile'
	Content:= 'GVL.Variable',
	HasError=> , 
	ErrorId=> );
```

### The JSON Attribute

This software can parse and convert normal DUTs (also nested DUTs) into Json object thaks to the power of [TwinCAT.JsonExtension](https://github.com/fbarresi/TwinCAT.JsonExtension).
The only things you have to do is to add the JSON attribute to your code like follows and specify if your field has another json-name or can be used with its own name.

```
TYPE JsonDUT :
STRUCT
	{attribute 'json' := 'message'}
	sMessage : STRING;
	iResponse : INT;
	{attribute 'json' := 'status'}
	sStatus : STRING;
	{attribute 'json' := 'numbers'}
	daNumbers : ARRAY[1..10] OF DINT := [1,2,3,4,5,6,7,8,9,10];
	{attribute 'json'}
	child : ChildDUT;
END_STRUCT
END_TYPE
```
## Would you like to contribute?

Yes, please!

Try the library and feel free to open an issue or ask for support. 

Don't forget to **star this project**! 

## Other projects

Check other project you may be interested in:

- [BeckhoffS7Client](https://github.com/fbarresi/BeckhoffS7Client) S7 PLC communication library.
- [BeckhoffHttpClient](https://github.com/fbarresi/BeckhoffHttpClient) HTTP Client for Beckhoff PLC.
- [TwinCatAdsTool](https://github.com/fbarresi/TwinCatAdsTool) Management tool for every TwinCat PLC

## Credits

Special thanks to [JetBrains](https://www.jetbrains.com/?from=BeckhoffJsonReadWriter) for supporting this open source project.

<a href="https://www.jetbrains.com/?from=BeckhoffJsonReadWriter"><img height="200" src="https://www.jetbrains.com/company/brand/img/jetbrains_logo.png"></a>
