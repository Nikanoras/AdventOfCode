namespace Day7.App
{
    public abstract class DeviceItem
    {
        public DeviceItem(string name, DeviceItem? parent)
        {
            Name = name;
            Parent = parent;
        }

        public string Name { get; }
        public DeviceItem? Parent { get; }
        public abstract long GetSize();
    }

    public class DeviceDirectory : DeviceItem
    {
        private readonly List<DeviceItem> _children = new();

        public DeviceDirectory(string name, DeviceDirectory? parent) : base(name, parent)
        {
        }

        public void AddChild(DeviceItem item)
        {
            _children.Add(item);
        }

        public IReadOnlyList<DeviceItem> GetChildren()
        {
            return _children.AsReadOnly();
        }

        public override long GetSize()
        {
            return _children.Sum(x => x.GetSize());
        }
    }

    public class DeviceFile : DeviceItem
    {
        private readonly long _size;

        public DeviceFile(string name, long size, DeviceDirectory parent) : base(name, parent)
        {
            _size = size;
        }


        public override long GetSize()
        {
            return _size;
        }
    }
}
