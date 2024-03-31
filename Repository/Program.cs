using Repository.Models;
using Repository.RepositoryBeer;

using (var context = new PatternsContext())
{
    var repositoryBeer = new RepositoryBeer(context);
    var repository = new Repository<Brand>(context);

    var beer = new Beer();
    beer.Name = "Brahama";
    beer.Style = "Negra";

    var brand = new Brand();
    brand.Name = "Soy brand";
    repository.Add(brand);

    repositoryBeer.Add(beer);

    repositoryBeer.Save();
    repository.Save();

    foreach(var b in repositoryBeer.Get())
    {
        Console.WriteLine($"{b.Name} {b.Style}");
    }

    Console.WriteLine("Ahora los Brands...");

    foreach(var b in repository.Get())
    {
        Console.WriteLine(b.Name);
    }

}
