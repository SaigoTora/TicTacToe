using System;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeLibrary
{
	internal class Node
	{
		private static readonly Random _random = new Random();

		private static int _maxDepthLevel;
		private static CellType _firstCellType;

		private readonly Field _field;
		private readonly int _depthLevel;

		private List<Node> _children;
		private byte _rating;

		internal Node(Field field, CellType childrenCellType, int maxDepthLevel)
		{// Constructor for the first node
			_field = (Field)field.Clone();

			_firstCellType = childrenCellType;
			_maxDepthLevel = maxDepthLevel;

			CreateChildren(childrenCellType);

			SetRating(childrenCellType);
		}
		internal Node(Field field, CellType childrenCellType, int depthLevel, bool hasChildren)
		{// Constructor for other nodes
			_field = (Field)field.Clone();
			_depthLevel = depthLevel;

			if (hasChildren && _depthLevel <= _maxDepthLevel)
				CreateChildren(childrenCellType);

			SetRating(childrenCellType);
		}

		private void CreateChildren(CellType childrenCellType)
		{
			int fieldSize = _field.GetFieldSize();
			_children = new List<Node>();
			bool hasChildren;

			for (int i = 0; i < fieldSize; i++)
				for (int j = 0; j < fieldSize; j++)
					if (_field.GetCell(new Cell(i, j)) == CellType.None)
					{
						_field.FillCell(new Cell(i, j), childrenCellType);// Temporarily fill the cell

						hasChildren = !_field.IsGameEnd(false);
						CellType nextCellType = childrenCellType == CellType.Cross ? CellType.Zero : CellType.Cross;
						_children.Add(new Node(_field, nextCellType, _depthLevel + 1, hasChildren));

						_field.FillCell(new Cell(i, j), CellType.None);// Returning the cell type back
					}
		}
		private void SetRating(CellType childrenCellType)
		{
			if (_children == null)
			{// Rating for leaves
				if (_field.Winner == _firstCellType)
					_rating = 4;
				else if (_field.Winner == CellType.None)
				{
					if (_field.CountFilledCells() == _field.GetFieldSize() * _field.GetFieldSize())
						_rating = 2;// If all cells are filled
					else
						_rating = 3;
				}
				else
					_rating = 1;
			}
			else
			{// Rating for other nodes (minimax procedure)
				_rating = childrenCellType == _firstCellType
					? _children.Max(child => child._rating)
					: _children.Min(child => child._rating);
			}
		}

		internal Cell FindMaxRating()
		{
			Cell? resultCell;

			foreach (Node child in _children)
				if (child._field.Winner == _firstCellType)
				{// If there is a win in the current child field
					resultCell = _field.GetFirstCellMismatch(child._field.GetAllCells());
					if (resultCell.HasValue)
						return resultCell.Value;
				}

			byte maxRating = _children.Max(child => child._rating);

			List<Cell> perfectCells = new List<Cell>();
			foreach (Node child in _children)
				if (child._rating == maxRating)
				{
					resultCell = _field.GetFirstCellMismatch(child._field.GetAllCells());
					if (resultCell.HasValue)
						perfectCells.Add(resultCell.Value);
				}

			// Select a random cell from perfectCells
			if (perfectCells.Count > 0)
				return perfectCells[_random.Next(perfectCells.Count)];
			else
				throw new InvalidOperationException("No perfect cells found.");
		}
	}
}