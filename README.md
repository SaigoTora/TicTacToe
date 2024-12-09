# Description
Play the classic game of **Tic Tac Toe** with fun new features that make every match more exciting and rewarding!

- **Earn coins** by:  
  - Playing against a bot with adjustable difficulty. The harder the bot, the more coins you win — but losing costs you coins.  
  - Competing in local games, where coins are earned if you win more rounds than your opponent. In this mode, you either lose your bet or win **double your bet**!

- **Spend coins** in the shop to:  
  - Customize your game with avatars, menu backgrounds, and board colors.  
  - Purchase helpful game assistants to boost your chances of winning.

- **Choose your gameplay mode:**  
  - Play with a friend on **one PC**.  
  - Compete in **local network matches**.  
  - Explore unique **game modes** for extra fun.

- **Track your progress** with detailed game stats to see how you improve over time.

Experience Tic Tac Toe like never before!

# Technology stack
The project is developed in the **C#** programming language using **Windows Forms** to create the user interface.  
The following NuGet packages were integrated during the development process:
- **FluentValidation 11.10.0** — for convenient and flexible data validation.
- **FontAwesome.Sharp 6.6.0** — to improve the visual part of the interface with icons.
- **Guna.UI2.WinForms 2.0.4.6** — to improve the aesthetics and functionality of the interface elements.
- **Newtonsoft.Json 13.0.3** — for converting objects to JSON format for transmission via HTTP methods.

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
1. When you start the game, the start form will appear. Enter your game nickname and choose an initial avatar.
2. After clicking the "Ready" button, the game menu will open. The following options will be available:
   - **Play** — start a new game against the bot.
   - **Select Game Parameters** — configure bot difficulty, number of rounds, and game mode for playing with the bot.
   - **Single PC** — play a two-player game on a single PC.
   - **Local Game** — start a game on a local network.
   - **Profile** — view and change personal information.
   - **Shop** — purchase in-game items using earned coins.

That's all. Good luck and have fun!
