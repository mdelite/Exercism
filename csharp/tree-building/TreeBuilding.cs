using System;
using System.Collections.Generic;
using System.Linq;

public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }
}

public class Tree : IComparable
{
    public Tree(TreeBuildingRecord r)
    {
        if(r.RecordId == 0 && r.ParentId != 0) throw new ArgumentException($"{nameof(r.RecordId)} 0 must have {nameof(r.ParentId)} of 0.");
        if(r.RecordId != 0 && r.ParentId >= r.RecordId) throw new ArgumentException($"{nameof(r.ParentId)}:'{r.ParentId}' must be less than {nameof(r.RecordId)}:'{r.RecordId}'");

        Id = r.RecordId;
        ParentId = r.ParentId;

        Children = new List<Tree>();
    }

    public int Id { get; }
    public int ParentId { get; }
    public List<Tree> Children { get; }

    public bool IsLeaf => Children.Count() == 0;

    public int CompareTo(object obj)
    {
        var t = obj as Tree;

        return this.Id - t.Id;
    }

    internal void AddBranches(IEnumerable<Tree> branches)
    {
        var trees = branches.Where(r => r.ParentId == this.Id)
            .ToList();

        trees.ForEach(t => t.AddBranches(branches.Where(r => r.Id > t.Id)));
        Children.AddRange(trees);
        Children.Sort();
    }
}

public static class TreeBuilder
{
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var c = records.Count();
        if(c == 0 || c - 1 != records.Select(rec => rec.RecordId).Max()) throw new ArgumentException();

        var tree = new Tree(records.First(r => r.RecordId == 0));
        var branches = records.Where(r => r.RecordId > 0).Select(x => new Tree(x));
        tree.AddBranches(branches);

        return tree;
    }
}