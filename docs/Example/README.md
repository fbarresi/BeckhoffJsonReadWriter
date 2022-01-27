Use the project in this folder in order to get the example running.

I assume you already prepared your PC or PLC in the right way by doing the following things:

- Install TFU0003 in your target
- Reference the BeckhoffJsonReadWriter library in your twincat project

If not:

Download and reference the [BeckhoffJsonReadWriter library](https://github.com/fbarresi/BeckhoffJsonReadWriter/releases/latest) and import it to your project.

![](https://github.com/fbarresi/BeckhoffJsonReadWriter/raw/master/docs/library.png)

After thar you can start using the BeckhoffJsonReadWriter.

# Usage

The usage if the example is very simple a screen recording will show you how to write and read json files

![](https://github.com/fbarresi/BeckhoffJsonReadWriter/raw/master/docs/example_in_action.gif)

# Troubleshooting

If you are still wondering what is going wrong you may probably want to see the log of the function. 
For enabling the log just copy the [log.config](https://github.com/fbarresi/BeckhoffJsonReadWriter/raw/master/TFU003/TFU003/log.config") into the function folder: `C:\TwinCAT\Functions\Unofficial\JsonReadWriter`.
Re-execute the parser for generate logs into `C:\TwinCAT\Functions\Unofficial\JsonReadWriter\logs`.
