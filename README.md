
# Description
This project offers users the opportunity to play the classic game of **Tic Tac Toe**, with some exciting elements to make the game more interesting.  
To enhance the gameplay, virtual coins were introduced. Users earn coins by defeating the bot, with several difficulty levels available.  
The more difficult the bot, the more coins you can earn for winning. However, if you lose, the number of coins will decrease.  
The earned coins can be spent in the game store on useful items.

# Technology stack
The project is developed in the **C#** programming language using **Windows Forms** to create the user interface.  
The following NuGet packages were integrated during the development process:
- **FluentValidation 11.9.2** — for convenient and flexible data validation.
- **FontAwesome.Sharp 6.6.0** — to improve the visual part of the interface with icons.
- **Guna.UI2.WinForms 2.0.4.6** — to improve the aesthetics and functionality of the interface elements.

# Installing and running the project

## Clone the repository
1. Open **Visual Studio**.
2. In the Start window, select **"Clone repository"**.
3. In the **"Repository location"** dialog, paste the following link:
   ```bash
   https://github.com/SaigoTora/TicTacToe.git
4. Select the path where the project will be cloned on your computer.
5. Click the **"Clone"** button.

## Installing dependencies
The project uses several NuGet packages. To install them:
1. Right-click the solution in **Solution Explorer**.
2. In the context menu, select **"Restore NuGet Packages"**. Visual Studio will automatically install all the necessary packages.

## Building and running the project
1. Press **Ctrl + Shift + B** to build the project.
2. Press **F5** to run the project in debug mode, or select **"Run without debugging"** (**Ctrl + F5**) for a normal run.

# Instructions for use
1. When you start the game, a start form opens, where you need to enter your game nickname and select an initial avatar.
2. After clicking the **"Ready"** button, the game menu will open, in which the following options are available:
   - **Start the game** — start a new match.
   - **Select game parameters** — adjust the bot difficulty, number of rounds, and other parameters.
   - **Profile** — view and change personal information.
   - **Shop** — purchase in-game items for earned coins.

That's all. Good luck and have fun!
