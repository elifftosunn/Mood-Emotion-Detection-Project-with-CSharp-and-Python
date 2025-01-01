from ultralytics import YOLO
import sys
import os
import shutil

def determine_mood(results):
    labels = []
    if results and hasattr(results[0], 'boxes') and results[0].boxes is not None:
        try:
            boxes_data = results[0].boxes.data.tolist()
            labels = [results[0].names[int(box[5])] for box in boxes_data] #  [974.456787109375, 85.58895111083984, 1637.2952880859375, 979.904052734375, 0.8699231743812561, 0.0]
            labels = [label.lower() for label in labels]  
        except Exception as e:
            print(f"Error processing boxes: {e}")
    if 'happy' in labels or 'smile' in labels or 'positive' in labels:
        return "positive"
    elif 'sad' in labels or 'cry' in labels or 'negative' in labels:
        return "negative"
    else:
        return "neutral"



def main():
    if len(sys.argv) < 2:
        print("Error: No image path provided.")
        return
    image_path = sys.argv[1]

    # check the image
    if not os.path.exists(image_path):
        print("Error: The provided image path does not exist.")
        return

    # upload model file
    model_path = r"C:\Users\dptos\source\repos\designProject\designProject\yoloModels\yolov8_best.pt"
    if not os.path.exists(model_path):
        print("Error: The model file does not exist.")
        return

    # create file name and target folder
    image_name = os.path.basename(image_path)  # for example: "happy-photo.jpg"
    detected_dir = os.path.join(os.path.dirname(__file__), "detected_images")
    os.makedirs(detected_dir, exist_ok=True) # create folder if it doesn't exist

    model = YOLO(model_path)

    # Run YOLO prediction
    results = model.predict(source=image_path, save=True)
    for i, result in enumerate(results):
        if hasattr(result, "boxes") and result.boxes is not None:
            try:
                print(f"Names: {result.names}") # Names: {0: 'positive', 1: 'neutral', 2: 'negative'}
                boxes_data = result.boxes.data.tolist()
            except Exception as e:
                print(f"Error accessing boxes data: {e}")



    # the folder where YOLO saves the output
    save_dir = results[0].save_dir if results else None
    if not save_dir:
        print("Error: YOLO did not produce a save directory.")
        return
    saved_output_path = os.path.join(save_dir, image_name)  # YOLO's saved file path
    target_output_path = os.path.join(detected_dir, image_name)  # target file path
    print(f"Target output path: {target_output_path}")
    if not os.path.exists(target_output_path):
        print(f"Error: Target output path does not exist!")
    # Determine mood based on detection results
    mood = determine_mood(results)

    # check the output file and move
    if os.path.exists(saved_output_path):
        shutil.move(saved_output_path, target_output_path)

        # Write the result in a file
        output_file = os.path.join(detected_dir, "output.txt")
        with open(output_file, "w") as f:
            f.write(f"{target_output_path}, {mood}")  # Write destination path and mood
    else:
        print(f"Error: Output file not found in {save_dir}. Check YOLO execution.") 


if __name__ == "__main__":
    main()
