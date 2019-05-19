using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

public class Node : IEnumerable, IEquatable<Node>
{
    public string Name;
    public string Type;
    public string Value;

    public Node(string name)
    {
        this.Name = name;
    }

    public void Add(string type, string val)
    {
        this.Type = type;
        this.Value = val;
    }

    public bool Equals(Node other)
    {
        return other != null &&
            other.Name == this.Name &&
            other.Type == this.Type &&
            other.Value == this.Value;
    }

    public IEnumerator GetEnumerator()
    {
        yield return this.Name;
        yield return this.Type;
        yield return this.Value;
    }

    // public override int GetHashCode()
    // {
    //     var hash = 13;
    //     hash = hash * 7 + Name.GetHashCode();
    //     hash = hash * 7 + Type.GetHashCode();
    //     hash = hash * 7 + Value.GetHashCode();
    //     return hash;
    // }
}

public class Edge : IEnumerable, IEquatable<Edge>
{
    private string v1;
    private string v2;

    public Edge(string v1, string v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public void Add(string v1, string v2)
    {
        this.v1 = v1;
        this.v2 = v2;
    }

    public bool Equals(Edge other)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        yield return v1;
        yield return v2;
    }
}

public class Attr : IEnumerable, IEquatable<Attr>
{
    private string name;
    private string value;

    public Attr(string name, string val)
    {
        this.name = name;
        this.value = val;
    }

    public bool Equals(Attr other)
    {
        throw new NotImplementedException();
    }

    public IEnumerator GetEnumerator()
    {
        yield return name;
        yield return value;
    }
}

public class Graph : IEnumerable
{
    List<Node> _nodes = new List<Node>();
    public Graph()
    {

    }
    public List<Node> Nodes { set; get; } = new List<Node>();
    public List<Edge> Edges { get;  set; } = new List<Edge>();
    public List<Attr> Attrs { get;  set; } = new List<Attr>();

    public void Add(Node node)
    {
        _nodes.Add(node);
    }

    public void Add(Edge edge)
    {
        Edges.Add(edge);
    }

    public void Add(string type, string value)
    {
        Attrs.Add(new Attr(type, value));
    }

    public IEnumerator GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}