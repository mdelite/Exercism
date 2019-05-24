using System;
using System.Collections;
using System.Collections.Generic;

public class Node : Element
{
    public string Name { get; }
    public Node(string v)
    {
        this.Name = v;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != this.GetType()) return false;

        return ((Node)obj).Name == this.Name;
    }

    public override int GetHashCode() => Name.GetHashCode();
}

public class Edge : Element
{
    public string Start { get; }
    public string End { get; }

    public Edge(string start, string end)
    {
        this.Start = start;
        this.End = end;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != this.GetType()) return false;

        return ((Edge)obj).Start == this.Start && ((Edge)obj).End == this.End;
    }

    public override int GetHashCode() => Start.GetHashCode() ^ End.GetHashCode();
}

public class Attr
{
    public string Key { get; }
    public string Value { get; }

    public Attr(string key, string val)
    {
        this.Key = key;
        this.Value = val;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != this.GetType()) return false;
        return ((Attr)obj).Key == this.Key && ((Attr)obj).Value == this.Value;
    }

    public override int GetHashCode() => Key.GetHashCode() ^ Value.GetHashCode();

}

public class Graph : Element
{
    public HashSet<Node> Nodes { get; }
    public HashSet<Edge> Edges { get; }

    public Graph()
    {
        Nodes = new HashSet<Node>();
        Edges = new HashSet<Edge>();
    }
    public void Add(Node node) => this.Nodes.Add(node);
    public void Add(Edge edge) => this.Edges.Add(edge);
}

public abstract class Element : IEnumerable<Attr>
{
    public HashSet<Attr> Attrs { get; protected set; }
    public Element() => Attrs = new HashSet<Attr>();

    public IEnumerator<Attr> GetEnumerator() => Attrs.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public void Add(string key, string value) => Attrs.Add(new Attr(key, value));
}