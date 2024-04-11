namespace Itmo.ObjectOrientedProgramming.Lab2.RepositoryDirectory;

public interface IRepository<T>
{
    void Add(T newComponent);
    T? Receive(string name);
}