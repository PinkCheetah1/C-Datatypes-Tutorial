namespace BinaryTree;

public class Node {
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data) {
        Data = data;
    }

    public void Insert(int value)
    {
        if (value < Data) {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else if (value > Data) {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value) {
        if (value == Data) {
            return true;
        }
        else if (value < Data) {
            if (Left is null)
            {
                return false;
            }
            else {
                return Left.Contains(value);
            }
        }
        else if (value > Data) {
            if (Right is null) {
                return false;
            }
            else {
                return Right.Contains(value);
            }
        }
        return false;
    }

    public int GetHeight() {
        int leftHeight;
        int rightHeight;

        // Get height for Left
        if (Left is null) {
            leftHeight = 0;
        }
        else {
            leftHeight = Left.GetHeight();
        }

        // Get height for Right
        if (Right is null) {
            rightHeight = 0;
        }
        else {
            rightHeight = Right.GetHeight();
        }

        if (rightHeight > leftHeight) {
            return rightHeight + 1;
        }
        else { 
            return leftHeight + 1;
        }
    }
}