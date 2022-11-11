using System;

namespace WebAPI.Models.API;

public class Product
{
	public int Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public string Image { get; set; }
	public string Location { get; set; }

	public int Price => GetValue();

	int GetValue()
	{
		var RandomNumberGenerator = new Random();
		return RandomNumberGenerator.Next(0, 10);
	}
}