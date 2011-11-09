##DocumentMall Export Connector

###Overview:
The DocumentMall Export Connector will allow Kofax Express to export a batch with an XML file that can be read by the Upload Agent to import batches into DocumentMall.

###Installation:
The DocumentMall Export Connector requires Kofax Express and will run on any operating system that it supported by [Kofax Express](http://www.kofax.com/express/technical-specifications.asp).  To install, extract all files from the included zip file and execute setup.exe. 
Configuration: 

###Usage 
1. Account: This is the account name you are sending the documents to. This will populate the <docbase> tag.
2. Owner: This is the user sending the documents. This populates the user tag.
3. DocumentMall watch folder: The local folder where the Upload agent scans for new batches.
4. DocumentMall folder path: This is the path where the documents will be released in DocumentMall. This is a UNIX style folder.
5. Document file name: The name of the image files.
6. Document Type: The type of document being exported. This can be a static field or can be populated from an index field. These types need to be defined in DocumentMall first. Populates the doctype tag.
7. Security Key: The Permission Set Name (security key or ACL name) as defined in DocumentMall. This can be a static value or taken from an index field.

###Copyright
Copyright 2011 Kofax, Inc.

Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License.

You may obtain a copy of the License at

[http://www.apache.org/licenses/LICENSE-2.0](http://www.apache.org/licenses/LICENSE-2.0)

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.