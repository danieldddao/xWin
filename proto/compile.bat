./bin/protoc --csharp_out=../xWin/xWin/Config ./mouse_control.proto
protoc --csharp_out=. ./mouse_control.proto
protoc --csharp_out=./test/test ./mouse_control.proto

protoc --csharp_out=../xWin/xWin/Config ./keyboard_control.proto
protoc --csharp_out=. ./keyboard_control.proto
protoc --csharp_out=./test/test ./keyboard_control.proto

protoc --csharp_out=../xWin/xWin/Config ./save_format.proto
protoc --csharp_out=. ./save_format.proto
protoc --csharp_out=./test/test ./save_format.proto


pause